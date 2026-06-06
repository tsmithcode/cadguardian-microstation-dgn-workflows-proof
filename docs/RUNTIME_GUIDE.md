# Runtime Guide

## Public runtime

The default kit runs with local .NET and does not require licensed CAD software.

```bash
dotnet run --project quickstart
```

## Native runtime

Use C# for package readiness, then a MicroStation-native adapter only after seed, level, reference, and export policy are accepted.

Native examples are intentionally optional. They should be used only inside the matching licensed CAD environment after the package boundary is proven.

## Native handoff points

- **Seed file inventory:** `DgnFile`, `DgnModel`, and seed-file policy in a MicroStation-native runtime.
- **Level, cell, and reference boundary:** `Level`, `Cell`, element traversal, and reference attachment checks.
- **Export package risk:** MicroStation Python or SDK adapter once export policy is accepted.
