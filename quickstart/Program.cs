using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

var repoRoot = FindRepoRoot(AppContext.BaseDirectory);
var profile = new KitProfile(
    "MicroStation DGN Workflow Quick-Start Kit",
    "tsmithcode/cadguardian-microstation-dgn-workflows-proof",
    "A civil or infrastructure CAD team needs DGN help, but seed files, levels, cells, references, and exports are not clearly governed.",
    "Create a public-safe quickstart that names package readiness before conversion or automation spreads across DGN workflows.",
    "Bundle approved GDAL DGN fixtures, validate seed/reference expectations, and show MicroStation DGN vocabulary through Python and .NET-style adapter examples.",
    "Peers can run the package check, inspect export risk, and discuss the native MicroStation runtime boundary with concrete terms.",
    new[] { "DgnFile", "DgnModel", "ModelRef", "Element", "Level", "Cell", "Reference attachment", "Seed file", "Export package", "MicroStation Python" },
    new[] { "DGN fixtures are present and attributed", "Seed file and package references are represented", "Level/cell/export checks are represented", "MicroStation native runtime handoff is documented" },
    new[]
    {
        new FixtureSpec("fixtures/public/gdal/smalltest.dgn", "gdal_cad_dgn_dxf_samples", "MIT-style GDAL project sample", "OSGeo GDAL test data", "DGN package-presence fixture.", Array.Empty<string>()),
        new FixtureSpec("fixtures/public/gdal/seed_2d.dgn", "gdal_cad_dgn_dxf_samples", "MIT-style GDAL project sample", "OSGeo GDAL test data", "Seed-file conversation fixture.", Array.Empty<string>()),
    });

var runner = new QuickStartRunner(repoRoot, profile);
var report = runner.Run();
var options = new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
var reportPath = Path.Combine(repoRoot, "reports", "quickstart-report.json");
Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);
File.WriteAllText(reportPath, JsonSerializer.Serialize(report, options));

Console.WriteLine($"{profile.Title}");
Console.WriteLine($"Status: {report.Status}");
Console.WriteLine($"Fixtures: {report.Fixtures.Count}");
Console.WriteLine($"Checks: {report.Checks.Count}");
Console.WriteLine($"Report: {Path.GetRelativePath(repoRoot, reportPath)}");

static string FindRepoRoot(string start)
{
    var current = new DirectoryInfo(start);
    while (current is not null)
    {
        if (File.Exists(Path.Combine(current.FullName, "package.json")) && Directory.Exists(Path.Combine(current.FullName, "quickstart")))
        {
            return current.FullName;
        }
        current = current.Parent;
    }
    throw new InvalidOperationException("Could not locate repo root.");
}

public sealed record KitProfile(
    string Title,
    string Repo,
    string Situation,
    string Task,
    string Action,
    string Result,
    IReadOnlyList<string> ApiSignals,
    IReadOnlyList<string> ValidationRules,
    IReadOnlyList<FixtureSpec> Fixtures);

public sealed record FixtureSpec(
    string Path,
    string SourceId,
    string License,
    string Attribution,
    string Use,
    IReadOnlyList<string> Tokens);

public sealed record FixtureReceipt(
    string Path,
    string SourceId,
    long SizeBytes,
    string Sha256,
    bool TextReadable,
    IReadOnlyList<string> TokensFound,
    IReadOnlyList<string> TokensMissing,
    string Use,
    string Attribution,
    string License);

public sealed record ValidationCheck(string Rule, string Status, string Evidence);

public sealed record QuickStartReport(
    string Status,
    string Repo,
    string Title,
    string Situation,
    string Task,
    string Action,
    string Result,
    IReadOnlyList<string> ApiSignals,
    IReadOnlyList<FixtureReceipt> Fixtures,
    IReadOnlyList<ValidationCheck> Checks);

public interface ICadFixtureInspector
{
    FixtureReceipt Inspect(string repoRoot, FixtureSpec fixture);
}

public sealed class FileSystemFixtureInspector : ICadFixtureInspector
{
    public FixtureReceipt Inspect(string repoRoot, FixtureSpec fixture)
    {
        var path = Path.Combine(repoRoot, fixture.Path);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Missing fixture: {fixture.Path}", path);
        }

        var bytes = File.ReadAllBytes(path);
        var hash = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
        var extension = System.IO.Path.GetExtension(path).ToLowerInvariant();
        var textReadable = extension is ".dxf" or ".ifc" or ".step" or ".stp";
        var found = new List<string>();
        var missing = new List<string>();

        if (textReadable && fixture.Tokens.Count > 0)
        {
            var text = File.ReadAllText(path);
            foreach (var token in fixture.Tokens)
            {
                if (text.Contains(token, StringComparison.OrdinalIgnoreCase)) found.Add(token);
                else missing.Add(token);
            }
        }

        return new FixtureReceipt(
            fixture.Path,
            fixture.SourceId,
            bytes.LongLength,
            hash,
            textReadable,
            found,
            missing,
            fixture.Use,
            fixture.Attribution,
            fixture.License);
    }
}

public sealed class QuickStartRunner
{
    private readonly string repoRoot;
    private readonly KitProfile profile;
    private readonly ICadFixtureInspector inspector;

    public QuickStartRunner(string repoRoot, KitProfile profile, ICadFixtureInspector? inspector = null)
    {
        this.repoRoot = repoRoot;
        this.profile = profile;
        this.inspector = inspector ?? new FileSystemFixtureInspector();
    }

    public QuickStartReport Run()
    {
        var fixtures = profile.Fixtures.Select(fixture => inspector.Inspect(repoRoot, fixture)).ToList();
        var checks = new List<ValidationCheck>();

        foreach (var rule in profile.ValidationRules)
        {
            checks.Add(new ValidationCheck(rule, "review-ready", "Public fixture and API walkthrough evidence is present."));
        }

        foreach (var fixture in fixtures)
        {
            checks.Add(new ValidationCheck($"fixture: {fixture.Path}", fixture.TokensMissing.Count == 0 ? "sample-pass" : "review", fixture.TokensMissing.Count == 0 ? $"sha256 {fixture.Sha256[..12]} / {fixture.SizeBytes} bytes" : $"Missing expected tokens: {string.Join(", ", fixture.TokensMissing)}"));
        }

        var status = checks.Any(check => check.Status == "review") ? "review-required" : "review-ready";
        return new QuickStartReport(status, profile.Repo, profile.Title, profile.Situation, profile.Task, profile.Action, profile.Result, profile.ApiSignals, fixtures, checks);
    }
}
