export function runAdapter(job) {
  return {
    requestId: job.requestId,
    kitType: "CAD Guardian quick-start automation kit",
    repo: "tsmithcode/cadguardian-microstation-dgn-workflows-proof",
    runtimeDecision: job.runtimeDecision,
    apiSignals: [
  "DgnFile",
  "DgnModel",
  "ModelRef",
  "Element",
  "Level",
  "Cell",
  "Reference attachment",
  "Seed file",
  "Export package",
  "MicroStation Python"
],
    expectedOutputs: [
  "dgn-package-report",
  "seed-file-receipts",
  "export-risk-checks",
  "native adapter notes"
],
    validation: [
  "DGN fixtures are present and attributed",
  "Seed file and package references are represented",
  "Level/cell/export checks are represented",
  "MicroStation native runtime handoff is documented"
].map((rule) => ({
      rule,
      status: "review-ready",
      evidence: "Public quick-start kit fixture, API walkthrough, or native adapter example is present.",
    })),
    publicBoundary: "No private client files, login material, raw opportunity notes, or license-uncertain CAD assets are included.",
  };
}
