using System;
using System.Collections.Generic;

using R5T.Cambridge.Types;


namespace R5T.Soltana
{
    public static class IVisualStudioSolutionFileOperatorExtensions
    {
        public static void AddProjectFile(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite, string projectFilePath)
        {
            visualStudioSolutionFileOperator.AddProjectFile(solutionFileSite.SolutionFile, solutionFileSite.Path, projectFilePath);
        }

        public static void RemoveProjectFile(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite, string projectFilePath)
        {
            visualStudioSolutionFileOperator.RemoveProjectFile(solutionFileSite.SolutionFile, solutionFileSite.Path, projectFilePath);
        }

        public static IEnumerable<string> ListProjectFiles(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite)
        {
            var projectFilePaths = visualStudioSolutionFileOperator.ListProjectFiles(solutionFileSite.SolutionFile, solutionFileSite.Path);
            return projectFilePaths
        }
    }
}
