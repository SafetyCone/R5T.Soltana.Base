using System;
using System.Collections.Generic;

using R5T.Cambridge.Types;


namespace R5T.Soltana
{
    /// <summary>
    /// A service for operating on (in-memory) <see cref="SolutionFile"/> instances.
    /// The <see cref="R5T.Soltana.IVisualStudioSolutionFileOperator"/> service:
    /// 1) Performs file path operations like adding or removing a project file.
    /// 2) Lists project-references, filtering out solution folders.
    /// 3) Creates new <see cref="SolutionFile"/> instances.
    /// </summary>
    /// <remarks>
    /// Throughout, a solution file path is required to turn relative paths in the solution file into absolute project file paths.
    /// </remarks>
    public interface IVisualStudioSolutionFileOperator
    {
        SolutionFile CreateNewSolutionFile();

        void AddProjectFile(SolutionFile solutionFile, string solutionFilePath, string projectFilePath, Guid projectTypeGuid);

        bool HasProjectFile(SolutionFile solutionFile, string solutionFilePath, string projectFilePath);

        bool RemoveProjectFile(SolutionFile solutionFile, string solutionFilePath, string projectFilePath);

        /// <summary>
        /// Lists solution project file references, NOT including any solution folders.
        /// </summary>
        IEnumerable<SolutionFileProjectFileReference> ListProjectFileReferences(SolutionFile solutionFile, string solutionFilePath);
    }
}
