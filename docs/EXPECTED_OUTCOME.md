# Expected Outcome

After running:

```bash
dotnet run --project quickstart
```

the repo writes:

```
reports/quickstart-report.json
```

The report must include:

- `Status`: `ready-for-private-sample` or `needs-review`.
- `BusinessImpact`: why this kit exists.
- `Fixtures`: approved public fixture receipts with size and SHA-256.
- `ParetoChecks`: checks tied to the first valuable automation slice.
- `ReusableRoutines`: the small code patterns meant to be adapted.
- `ApiSignals`: native/API vocabulary for the next technical conversation.

Expected first decision:

Pick one DGN package class, name the seed/reference/export checks, then decide whether a MicroStation-native adapter is justified.
