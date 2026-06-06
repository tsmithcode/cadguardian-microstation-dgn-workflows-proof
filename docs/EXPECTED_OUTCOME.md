# Expected Outcome

After running `npm run demo`, the repo writes:

```
reports/demo-validation-report.json
```

The report should contain:

- `requestId`: cadg-dgn-demo-001
- `runtimeDecision`: Readiness and validation package before DGN conversion, automation, or migration.
- `expectedOutputs`: level checklist, reference inventory, package manifest, export risk report
- `validation`: one review-ready row per validation rule
- `publicBoundary`: a reminder that private files and native CAD binaries are not bundled

## Stop conditions

The proof should stop instead of overclaiming when:

- Accepted output examples are missing.
- Native runtime execution cannot produce a local tool receipt.
- Reviewer ownership is unclear.
- The requested proof requires private files in a public repo.
