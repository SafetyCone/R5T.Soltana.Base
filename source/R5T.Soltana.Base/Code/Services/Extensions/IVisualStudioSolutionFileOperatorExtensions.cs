using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Cambridge.Types;


namespace R5T.Soltana.Extensions
{
    public static class IVisualStudioSolutionFileOperatorExtensions
    {
        public static SolutionFileSite CreateNewSolutionFileSite(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, string solutionFilePath)
        {
            var solutionFile = visualStudioSolutionFileOperator.CreateNewSolutionFile();

            var solutionFileSite = new SolutionFileSite()
            {
                SolutionFile = solutionFile,
                SolutionFilePath = solutionFilePath,
            };
            return solutionFileSite;
        }

        public static void AddProjectFile(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite, string projectFilePath, Guid projectTypeGuid)
        {
            visualStudioSolutionFileOperator.AddProjectFile(solutionFileSite.SolutionFile, solutionFileSite.SolutionFilePath, projectFilePath, projectTypeGuid);
        }

        public static bool HasProjectFile(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite, string projectFilePath)
        {
            var hasProjectFile = visualStudioSolutionFileOperator.HasProjectFile(solutionFileSite.SolutionFile, solutionFileSite.SolutionFilePath, projectFilePath);
            return hasProjectFile;
        }

        public static bool RemoveProjectFile(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite, string projectFilePath)
        {
            var removed = visualStudioSolutionFileOperator.RemoveProjectFile(solutionFileSite.SolutionFile, solutionFileSite.SolutionFilePath, projectFilePath);
            return removed;
        }

        public static IEnumerable<SolutionFileProjectFileReference> ListProjectFileReferences(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite)
        {
            var projectFileSpecifications = visualStudioSolutionFileOperator.ListProjectFileReferences(solutionFileSite.SolutionFile, solutionFileSite.SolutionFilePath);
            return projectFileSpecifications;
        }

        public static IEnumerable<string> ListProjectFilePaths(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFile solutionFile, string solutionFilePath)
        {
            var projectFileSpecifications = visualStudioSolutionFileOperator.ListProjectFileReferences(solutionFile, solutionFilePath);

            var projectFilePaths = projectFileSpecifications.Select(x => x.ProjectFilePathValue);
            return projectFilePaths;
        }

        public static IEnumerable<string> ListProjectFilePaths(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite)
        {
            var projectFilePaths = visualStudioSolutionFileOperator.ListProjectFilePaths(solutionFileSite.SolutionFile, solutionFileSite.SolutionFilePath);
            return projectFilePaths;
        }

        public static SolutionFileProjectFileReference GetProjectFileSpecification(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFile solutionFile, string solutionFilePath, string projectFilePath)
        {
            var projectFileSpecifications = visualStudioSolutionFileOperator.ListProjectFileReferences(solutionFile, solutionFilePath);

            var desiredProjectFileSpecification = projectFileSpecifications.Where(x => x.ProjectFilePathValue == projectFilePath).Single();
            return desiredProjectFileSpecification;
        }

        public static SolutionFileProjectFileReference GetProjectFileSpecification(this IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator, SolutionFileSite solutionFileSite, string projectFilePath)
        {
            var projectFileSpecification = visualStudioSolutionFileOperator.GetProjectFileSpecification(solutionFileSite.SolutionFile, solutionFileSite.SolutionFilePath, projectFilePath);
            return projectFileSpecification;
        }

        // Include adding a solution folder?

        // Add 
    }
}
