namespace task_scheduling_api.Utils
{
    public class PythonScriptInfo
    {
        public required string ScriptName { get; set; } // Name of the script (used as an API query parameter)
        public required string ScriptPath { get; set; } // Name of the script file in the scripts directory
        public required string OutputSource { get; set; } // Content source (stdout.txt, fileName.txt, etc.)
        public required string OutputType { get; set; } // Output type (text, file, etc.)
    }
}
