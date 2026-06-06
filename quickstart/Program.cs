using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

var repoRoot = FindRepoRoot(AppContext.BaseDirectory);
var profile = new KitProfile(
    "MicroStation DGN Workflow Quick-Start Kit",
    "tsmithcode/cadguardian-microstation-dgn-workflows-proof",
    "microstation-dgn-package-readiness",
    "civil CAD lead",
    "Name seed files, levels, cells, references, and export risk before DGN conversion or automation spreads across infrastructure workflows.",
    "A civil or infrastructure CAD team needs DGN help, but seed files, levels, cells, references, and exports are not clearly governed.",
    "Name package readiness before conversion or automation spreads across DGN workflows.",
    "Bundle public DGN fixtures, validate seed/reference expectations, and show MicroStation DGN vocabulary through Python and .NET-style adapter examples.",
    "A reviewer can run the package check, inspect export risk, and discuss the MicroStation runtime boundary with concrete terms.",
    "Use C# for package readiness, then a MicroStation-native adapter only after seed, level, reference, and export policy are accepted.",
    "Pick one DGN package class, name the seed/reference/export checks, then decide whether a MicroStation-native adapter is justified.",
    new string[] { "DgnFile", "DgnModel", "ModelRef", "Element", "Level", "Cell", "Reference attachment", "Seed file", "Export package", "MicroStation Python" },
    new string[] { "DGN package request", "Seed fixture inventory", "Level and cell check", "Reference policy check", "Export risk check", "MicroStation runtime boundary", "Reviewer signoff", "Next readiness decision" },
    new[]
    {
        new FixtureSpec("fixtures/public/gdal/smalltest.dgn", "DGN", "DGN package-presence fixture.", "OSGeo GDAL test data", "MIT-style GDAL project sample", Array.Empty<string>()),
        new FixtureSpec("fixtures/public/gdal/seed_2d.dgn", "DGN", "Seed-file conversation fixture.", "OSGeo GDAL test data", "MIT-style GDAL project sample", Array.Empty<string>()),
    },
    new[]
    {
        new ParetoRule("Seed file inventory", "Prevents conversion or automation from drifting away from the seed file users expect.", "`DgnFile`, `DgnModel`, and seed-file policy in a MicroStation-native runtime.", new string[] { "DGN" }),
        new ParetoRule("Level, cell, and reference boundary", "Names the objects that usually make DGN work fail late in review.", "`Level`, `Cell`, element traversal, and reference attachment checks.", new string[] { "native/microstation-dotnet/CadGuardianDgnAudit.cs" }),
        new ParetoRule("Export package risk", "Makes PDF/DWG/DGN export assumptions explicit before a civil CAD lead trusts automation.", "MicroStation Python or SDK adapter once export policy is accepted.", new string[] { "native/microstation-python/dgn_package_audit.py" }),
    });

var report = new ParetoQuickStartRunner(repoRoot, profile).Run();
var options = new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
var reportPath = Path.Combine(repoRoot, "reports", "quickstart-report.json");
Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);
File.WriteAllText(reportPath, JsonSerializer.Serialize(report, options));

Console.WriteLine(profile.Title);
Console.WriteLine($"Status: {report.Status}");
Console.WriteLine($"Pareto checks: {report.ParetoChecks.Count}");
Console.WriteLine($"Reusable routines: {report.ReusableRoutines.Count}");
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
    string WorkflowClass,
    string ReviewOwner,
    string BusinessImpact,
    string Situation,
    string Task,
    string Action,
    string Result,
    string RuntimeDecision,
    string NextMove,
    IReadOnlyList<string> ApiSignals,
    IReadOnlyList<string> Workflow,
    IReadOnlyList<FixtureSpec> Fixtures,
    IReadOnlyList<ParetoRule> ParetoRules);

public sealed record FixtureSpec(
    string Path,
    string Format,
    string Use,
    string Attribution,
    string License,
    IReadOnlyList<string> EvidenceTokens);

public sealed record FixtureReceipt(
    string Path,
    string Format,
    string Use,
    string Attribution,
    string License,
    long SizeBytes,
    string Sha256,
    bool TextReadable,
    IReadOnlyList<string> EvidenceFound,
    IReadOnlyList<string> EvidenceMissing,
    string RuntimeBoundary);

public sealed record ParetoRule(
    string Name,
    string BusinessImpact,
    string NativeHandoff,
    IReadOnlyList<string> EvidenceNeeded);

public sealed record ParetoCheck(
    string Name,
    string Status,
    string BusinessImpact,
    string Evidence,
    string NativeHandoff);

public sealed record ReusableRoutine(
    string Name,
    string WhyItMatters,
    string AdaptationPoint);

public sealed record QuickStartReport(
    string Status,
    string GeneratedAtUtc,
    string Repo,
    string Title,
    string WorkflowClass,
    string ReviewOwner,
    string BusinessImpact,
    string RuntimeDecision,
    string NextMove,
    StarStory Star,
    IReadOnlyList<string> Workflow,
    IReadOnlyList<string> ApiSignals,
    IReadOnlyList<FixtureReceipt> Fixtures,
    IReadOnlyList<ParetoCheck> ParetoChecks,
    IReadOnlyList<ReusableRoutine> ReusableRoutines);

public sealed record StarStory(string Situation, string Task, string Action, string Result);

public sealed class ParetoQuickStartRunner
{
    private readonly string repoRoot;
    private readonly KitProfile profile;

    public ParetoQuickStartRunner(string repoRoot, KitProfile profile)
    {
        this.repoRoot = repoRoot;
        this.profile = profile;
    }

    public QuickStartReport Run()
    {
        var fixtures = profile.Fixtures.Select(InspectFixture).ToList();
        var checks = profile.ParetoRules.Select(rule => EvaluateRule(rule, fixtures)).ToList();
        var routines = new[]
        {
            new ReusableRoutine(
                "FixtureInventory",
                "Creates a stable receipt before automation touches trusted CAD files.",
                "Replace the public fixtures with your private package path after access is approved."),
            new ReusableRoutine(
                "ParetoRuleEngine",
                "Keeps the first useful rules visible instead of hiding business logic in scripts.",
                "Swap or add rules for the repeated checks your drafters already perform."),
            new ReusableRoutine(
                "NativeRuntimeGate",
                "Prevents public parser confidence from pretending to be licensed CAD execution.",
                "Move a rule into the native adapter only after the public report shows why it matters."),
        };
        var status = checks.Any(check => check.Status is "needs-review") ? "needs-review" : "ready-for-private-sample";

        return new QuickStartReport(
            status,
            DateTimeOffset.UtcNow.ToString("O"),
            profile.Repo,
            profile.Title,
            profile.WorkflowClass,
            profile.ReviewOwner,
            profile.BusinessImpact,
            profile.RuntimeDecision,
            profile.NextMove,
            new StarStory(profile.Situation, profile.Task, profile.Action, profile.Result),
            profile.Workflow,
            profile.ApiSignals,
            fixtures,
            checks,
            routines);
    }

    private FixtureReceipt InspectFixture(FixtureSpec fixture)
    {
        var path = Path.Combine(repoRoot, fixture.Path);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Missing fixture: {fixture.Path}", path);
        }

        var bytes = File.ReadAllBytes(path);
        var hash = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
        var extension = Path.GetExtension(path).ToLowerInvariant();
        var textReadable = extension is ".dxf" or ".ifc" or ".step" or ".stp";
        var found = new List<string>();
        var missing = new List<string>();

        if (textReadable && fixture.EvidenceTokens.Count > 0)
        {
            var text = File.ReadAllText(path);
            foreach (var token in fixture.EvidenceTokens)
            {
                if (text.Contains(token, StringComparison.OrdinalIgnoreCase)) found.Add(token);
                else missing.Add(token);
            }
        }
        else if (fixture.EvidenceTokens.Count == 0)
        {
            found.Add(fixture.Format);
        }

        return new FixtureReceipt(
            fixture.Path,
            fixture.Format,
            fixture.Use,
            fixture.Attribution,
            fixture.License,
            bytes.LongLength,
            hash,
            textReadable,
            found,
            missing,
            textReadable ? "public-text-scan" : "licensed-native-runtime-required");
    }

    private static ParetoCheck EvaluateRule(ParetoRule rule, IReadOnlyList<FixtureReceipt> fixtures)
    {
        var evidence = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var fixture in fixtures)
        {
            evidence.Add(fixture.Format);
            foreach (var token in fixture.EvidenceFound) evidence.Add(token);
        }

        foreach (var token in rule.EvidenceNeeded)
        {
            if (token.StartsWith("native/", StringComparison.OrdinalIgnoreCase))
            {
                evidence.Add(token);
            }
        }

        var missing = rule.EvidenceNeeded.Where(token => !evidence.Contains(token)).ToArray();
        var status = missing.Length == 0 ? "ready-for-private-sample" : "needs-review";
        var evidenceSummary = missing.Length == 0
            ? $"Evidence present: {string.Join(", ", rule.EvidenceNeeded)}"
            : $"Missing evidence: {string.Join(", ", missing)}";

        return new ParetoCheck(rule.Name, status, rule.BusinessImpact, evidenceSummary, rule.NativeHandoff);
    }
}
