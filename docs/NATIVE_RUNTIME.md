# Native Runtime

The public kit runs without licensed CAD software. The examples in `native/` are intentionally optional.

## Runtime decision

Use C# for package readiness, then a MicroStation-native adapter only after seed, level, reference, and export policy are accepted.

## Native/API examples

- native/microstation-python/dgn_package_audit.py
- native/microstation-dotnet/CadGuardianDgnAudit.cs

## Rule

Do not claim native geometry mutation, conversion, plotting, PDM state changes, or model edits unless a local tool receipt is produced with approved files and tooling.
