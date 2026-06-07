<p align="left">
  <a href="https://www.cadguardian.com/services/microstation-dgn-workflows">
    <img src="assets/cad-guardian-logo-highlighted.png" alt="CAD Guardian logo" width="120">
  </a>
</p>

# MicroStation DGN Workflow Quick-Start Kit

Enterprise-facing public proof for CAD Guardian's [MicroStation DGN workflow service](https://www.cadguardian.com/services/microstation-dgn-workflows).

This repo proves a small, inspectable DGN package-readiness workflow before a team exposes private drawings, licensed MicroStation runtimes, or production automation.

Live proof page: [GitHub Pages](https://tsmithcode.github.io/cadguardian-microstation-dgn-workflows-proof/) | [Download ZIP](https://github.com/tsmithcode/cadguardian-microstation-dgn-workflows-proof/archive/refs/heads/main.zip) | [CAD Guardian](https://www.cadguardian.com/) | [TSmithCode.ai](https://www.tsmithcode.ai/)

## Best for

- Civil, infrastructure, plant, and facilities CAD teams that need a clearer DGN package boundary.
- Evaluators who want proof around seed files, levels, cells, references, and export risk before a sales call.
- CAD automation peers who need to see where local .NET checks stop and a MicroStation-native adapter begins.

## Decision this proves

Pick one DGN package class, name the seed/reference/export checks, then decide whether a MicroStation-native adapter is justified.

The proof is intentionally narrow: it validates package-readiness signals with approved public fixtures and names the handoff into MicroStation Python or a .NET-style SDK adapter only after the public boundary is accepted.

## Run locally

```bash
npm run doctor
npm run verify
npm run demo
npm run quickstart:build
npm run sanitize
```

`npm run demo` runs:

```bash
dotnet run --project quickstart
```

## Expected output

The demo writes:

```text
reports/quickstart-report.json
```

The report includes:

- `Status`: `ready-for-private-sample` or `needs-review`.
- `BusinessImpact`: why the DGN workflow proof exists.
- `Fixtures`: approved public DGN fixture receipts with size, SHA-256, attribution, and runtime boundary.
- `ParetoChecks`: seed file inventory; level, cell, and reference boundary; export package risk.
- `ReusableRoutines`: small package-readiness routines that can be adapted after access is approved.
- `ApiSignals`: `DgnFile`, `DgnModel`, `ModelRef`, `Element`, `Level`, `Cell`, reference attachments, seed files, export packages, and MicroStation Python.

## Proof boundary

This repository demonstrates the first useful evaluator question: can the team name the DGN package boundary before automation spreads?

It covers:

- Seed file inventory for DGN package conversations.
- Level, cell, and reference boundary language for late-review failure points.
- Export package risk for PDF/DWG/DGN handoffs.
- Public fixture receipts that make the proof reproducible without exposing client CAD data.

It does not claim to run licensed MicroStation APIs in public CI, inspect private DGN content, or certify production drawings.

## What to send

For a CAD Guardian review, send:

- The generated `reports/quickstart-report.json`.
- A short description of the DGN package class you want to govern.
- The seed, level, cell, reference, and export assumptions that currently create review risk.
- Whether the next step should stay in a local package-readiness check or move into a licensed MicroStation runtime.

Do not send credentials, private drawings, raw opportunity notes, client names, or unapproved CAD fixtures in this public repo.

## Related CAD Guardian page

[MicroStation DGN Workflows](https://www.cadguardian.com/services/microstation-dgn-workflows)

Use that service lane when the decision involves DGN standards, seed file policy, reference attachment checks, export readiness, or MicroStation-native automation planning.

## Native runtime boundary

The default quick-start runs with local .NET and approved public fixtures. It does not require licensed CAD software.

Native examples are intentionally optional:

- `native/microstation-python/dgn_package_audit.py`: MicroStation Python sketch for a configured MicroStation environment.
- `native/microstation-dotnet/CadGuardianDgnAudit.cs`: .NET-style SDK adapter boundary for `DgnFile`, `DgnModel`, elements, levels, cells, references, seed file policy, and export readiness.

Use C# for package readiness first. Move a rule into MicroStation Python or a native SDK adapter only after seed, level, reference, and export policy are accepted.

## Public fixture boundary

Only approved public sample files are bundled:

- `fixtures/public/gdal/smalltest.dgn`: DGN package-presence fixture from OSGeo GDAL test data.
- `fixtures/public/gdal/seed_2d.dgn`: seed-file conversation fixture from OSGeo GDAL test data.

No private names, credentials, private drawings/files, raw opportunity notes, or unapproved DGN/CAD fixtures belong in this repo.
