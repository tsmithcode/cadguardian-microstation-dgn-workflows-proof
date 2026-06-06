# API Walkthrough

## High-value API signals

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

## What the public C# quickstart does

- Reads the approved public fixture manifest.
- Validates fixture presence, size, hash, and text-readable markers where the format supports it.
- Writes `reports/quickstart-report.json`.
- Names the native/API boundary without claiming licensed runtime execution.

## Official references

- [Bentley MicroStation DGN Concepts](https://developer.bentley.com/documentation/microstation-python-api/pdf/04-MicroStationPython_Dgn_Concepts_API_Overview.pdf) - DGN, model, element, level, and file-concept vocabulary.
- [AWS API Gateway](https://docs.aws.amazon.com/apigateway/latest/developerguide/welcome.html) - API front door, job status, and artifact routes.
- [AWS Step Functions](https://docs.aws.amazon.com/step-functions/latest/dg/welcome.html) - State-machine orchestration, retries, and exception routing.
- [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) - Event-driven job functions when the platform standard is Azure.
- [Azure Service Bus](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview) - Queue-backed CAD work and service-bus vocabulary.
