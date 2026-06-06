# Runtime Guide

## Default public runtime

The default runtime is Node.js plus synthetic fixtures:

```bash
npm run doctor
npm run verify
npm run demo
```

Expected output: `reports/demo-validation-report.json`.

## Optional native/runtime path

Run:

```bash
npm run runtime:check
```

This command only reports visible local runtime hints. It does not prove CAD execution.

## Runtime decision for this proof

Readiness and validation package before DGN conversion, automation, or migration.

## AgentOps boundary

GDAL MIT DGN samples stay catalog-controlled. This repo publishes source manifests, synthetic package rules, and validation posture.

Native CAD files, private client material, credentials, source-system exports, and raw opportunity notes stay outside this public repo.
