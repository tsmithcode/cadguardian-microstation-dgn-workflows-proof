# MicroStation DGN Workflow Quick-Start Kit

CAD Guardian quick-start automation kit for peer walkthroughs, technical interviews, and buyer-facing business-case discussions.

> This CAD library is in development. This is an early public preview for feedback on the best business case, workflow shape, and proof path.

## STAR story

**Situation:** A civil or infrastructure CAD team needs DGN help, but seed files, levels, cells, references, and exports are not clearly governed.

**Task:** Create a public-safe quickstart that names package readiness before conversion or automation spreads across DGN workflows.

**Action:** Bundle approved GDAL DGN fixtures, validate seed/reference expectations, and show MicroStation DGN vocabulary through Python and .NET-style adapter examples.

**Result:** Peers can run the package check, inspect export risk, and discuss the native MicroStation runtime boundary with concrete terms.

## Fast run

```bash
npm run doctor
npm run verify
npm run demo
dotnet build quickstart
dotnet run --project quickstart
```

The C# quickstart writes `reports/quickstart-report.json`. The Node demo writes `reports/demo-validation-report.json`.

## What is included

- Runnable C# quickstart in `quickstart/`.
- Optional native/runtime examples in `native/`.
- Safe public fixtures in `fixtures/public/`.
- STAR story, API walkthrough, native runtime notes, interview script, and expected outcome docs.

## Workflow

- DGN package request
- Seed fixture inventory
- Level and cell check
- Reference policy check
- Export risk check
- MicroStation runtime boundary
- Reviewer signoff
- Next readiness decision

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
