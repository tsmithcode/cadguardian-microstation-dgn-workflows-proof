import { existsSync } from "node:fs";

const runtimeHints = [
  "MicroStation",
  "DGN",
  "levels",
  "cells",
  "references",
  "seed files",
  "exports"
];
const commonLocalHints = [
  "/Applications/Autodesk",
  "/Applications",
  "C:/Program Files/Autodesk",
  "C:/Program Files/SOLIDWORKS Corp",
  "C:/Program Files/Bentley",
];

const visibleHints = commonLocalHints.filter((path) => existsSync(path));

console.log("MicroStation DGN Workflow Readiness Proof");
console.log("Runtime vocabulary:", runtimeHints.join(", "));
console.log("Visible local runtime hints:", visibleHints.length > 0 ? visibleHints.join(", ") : "none detected");
console.log("This check does not prove CAD execution. Native geometry, conversion, repair, or API execution requires a separate local tool receipt.");
