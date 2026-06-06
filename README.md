# MicroStation DGN Workflow Quick-Start Kit

CAD Guardian Pareto quick-start automation kit for drafters, CAD automation peers, technical interviews, and buyer-facing business-case discussions.

> This CAD library is in development. This is an early public preview for feedback on the best business case, workflow shape, and proof path.

## Why this exists

Name seed files, levels, cells, references, and export risk before DGN conversion or automation spreads across infrastructure workflows.

## Fast run

```bash
npm run doctor
npm run verify
npm run demo
dotnet build quickstart
```

`npm run demo` runs the C# quickstart and writes `reports/quickstart-report.json`.

## What is worth reusing

- `quickstart/Program.cs`: a small C# package-readiness engine with fixture receipts, Pareto checks, native runtime gates, and a JSON report.
- `native/`: optional API/runtime examples for the licensed CAD environment.
- `fixtures/public/`: approved public CAD fixtures only.
- `docs/USER_GUIDE.md`: how to run and adapt the kit.
- `docs/INTERVIEW_SCRIPT.md`: how to explain the business case without guessing.

## STAR story

**Situation:** A civil or infrastructure CAD team needs DGN help, but seed files, levels, cells, references, and exports are not clearly governed.

**Task:** Name package readiness before conversion or automation spreads across DGN workflows.

**Action:** Bundle public DGN fixtures, validate seed/reference expectations, and show MicroStation DGN vocabulary through Python and .NET-style adapter examples.

**Result:** A reviewer can run the package check, inspect export risk, and discuss the MicroStation runtime boundary with concrete terms.

## Pareto checks

- **Seed file inventory:** Prevents conversion or automation from drifting away from the seed file users expect. Handoff: `DgnFile`, `DgnModel`, and seed-file policy in a MicroStation-native runtime.
- **Level, cell, and reference boundary:** Names the objects that usually make DGN work fail late in review. Handoff: `Level`, `Cell`, element traversal, and reference attachment checks.
- **Export package risk:** Makes PDF/DWG/DGN export assumptions explicit before a civil CAD lead trusts automation. Handoff: MicroStation Python or SDK adapter once export policy is accepted.

## API and runtime signals

- DgnFile
- DgnModel
- ModelRef
- Element
- Level
- Cell
- Reference attachment
- Seed file
- Export package
- MicroStation Python

## Public fixture boundary

Only approved public sample files are bundled. No client files, private drawings, credentials, raw opportunity notes, or license-uncertain CAD assets are included.

## Service page

https://www.cadguardian.com/services/microstation-dgn-workflows
