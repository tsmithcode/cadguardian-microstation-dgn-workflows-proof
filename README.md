# MicroStation DGN Workflow Readiness Proof

CAD Guardian proof repo for technical interviews, buyer reviews, and peer walkthroughs.

> This CAD library is in development. This is an early public preview for feedback on the best business case, workflow shape, and proof path.

## Story
A civil or infrastructure CAD team needs DGN workflow help, but seed files, levels, cells, references, exports, and package expectations need to be named first.

## Business case
The right proof is a readiness map and package-validation posture before conversion or automation decisions spread.

## Workflow
- DGN package request
- Seed and reference inventory
- Level/cell standards map
- Catalog-only DGN references
- Export/package policy
- Exception report
- Reviewer signoff
- Next readiness decision

## Stack vocabulary
- MicroStation
- DGN
- levels
- cells
- references
- seed files
- exports

## Run

```bash
npm run doctor
npm run verify
npm run demo
npm run sanitize
```

Expected demo output: `reports/demo-validation-report.json` with a review-ready status, validation checks, stop conditions, and the public CAD data boundary.

## Runtime model
This repo is tiered:

- Public demo: runs anywhere with Node.js and synthetic fixtures.
- Optional native/runtime check: `npm run runtime:check` reports whether local CAD/API tooling appears available.
- Real CAD files: stay in an AgentOps-controlled private library unless explicitly approved for a private runtime receipt.

## Guides
- [User guide](docs/USER_GUIDE.md)
- [Runtime guide](docs/RUNTIME_GUIDE.md)
- [API references](docs/API_REFERENCES.md)
- [Expected outcome](docs/EXPECTED_OUTCOME.md)
- [Development preview warning](docs/DEVELOPMENT_PREVIEW.md)

## Official references
- [Bentley MicroStation DGN Concepts](https://developer.bentley.com/documentation/microstation-python-api/pdf/04-MicroStationPython_Dgn_Concepts_API_Overview.pdf) - DGN, model, element, level, and file-concept vocabulary.
- [AWS API Gateway](https://docs.aws.amazon.com/apigateway/latest/developerguide/welcome.html) - API front door, status endpoints, and service boundary discussion.
- [AWS Step Functions](https://docs.aws.amazon.com/step-functions/latest/dg/welcome.html) - State-machine orchestration, retries, and staged workflow discussion.
- [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) - Event-driven job/API shape when the platform standard is Azure.
- [Azure Service Bus](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview) - Queue and service-bus vocabulary for async CAD work.

## Public CAD data boundary
GDAL MIT DGN samples stay catalog-controlled. This repo publishes source manifests, synthetic package rules, and validation posture.

This repository is built for public proof. It includes source inventory manifests, synthetic input fixtures, validation examples, and adapter code shaped for walkthroughs. It does not include private drawings, proprietary project files, login material, raw opportunity notes, or native CAD files that AgentOps marks catalog-only.

## Related service page
https://www.cadguardian.com/services/microstation-dgn-workflows
