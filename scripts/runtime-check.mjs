import { existsSync } from "node:fs";

const runtimeHints = [
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
];
const commonLocalHints = [
  "/Applications/Autodesk",
  "/Applications",
  "C:/Program Files/Autodesk",
  "C:/Program Files/SOLIDWORKS Corp",
  "C:/Program Files/Bentley",
];
const visibleHints = commonLocalHints.filter((path) => existsSync(path));

console.log("MicroStation DGN Workflow Quick-Start Kit");
console.log("API/native vocabulary:", runtimeHints.join(", "));
console.log("Visible local runtime hints:", visibleHints.length > 0 ? visibleHints.join(", ") : "none detected");
console.log("Public quickstart is runnable without licensed CAD. Native adapters require the matching local CAD/runtime environment.");
