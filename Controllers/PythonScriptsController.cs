using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using task_scheduling_api.Utils;

namespace task_scheduling_api.Controllers
{
    [ApiController]
    [Route("/v1/pythonScripts")]
    public class PythonScriptsController : ControllerBase
    {
        [HttpGet("runScript")]
        public async Task<IActionResult> script(string scriptName)
        {
            var info = PythonScriptRunner.GetInfoByName(scriptName);

            if (info == null) return BadRequest($"{scriptName} not found in scriptsInfo.json");

            var result = await PythonScriptRunner.RunScript(info.ScriptPath);

            var outputFile = Path.Combine(Environment.CurrentDirectory, result.workDir, info.OutputSource);

            if (info.OutputType == "file")
                return PhysicalFile(outputFile, "application/octet-stream", info.OutputSource);

            if (info.OutputType == "text")
                return Ok(System.IO.File.ReadAllText(outputFile));

            return BadRequest("no valid output type specifed in scriptsInfo.json");
        }
    }
}
