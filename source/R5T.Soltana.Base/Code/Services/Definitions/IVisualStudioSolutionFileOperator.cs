using System;
using System.Collections.Generic;

using R5T.Cambridge.Types;using R5T.T0064;


namespace R5T.Soltana
{[ServiceDefinitionMarker]
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
    public interface IVisualStudioSolutionFileOperator:IServiceDefinition
    {
        SolutionFile CreateNewSolutionFile();

        void AddProjectFile(SolutionFile solutionFile, string solutionFilePath, string projectFilePath, Guid projectTypeGuid, Guid projectGuid);

        bool HasProjectFile(SolutionFile solutionFile, string solutionFilePath, string projectFilePath, out SolutionFileProjectFileReference projectFileReference);

        bool RemoveProjectFile(SolutionFile solutionFile, string solutionFilePath, string projectFilePath);

        /// <summary>
        /// Lists solution project file references, NOT including any solution folders.
        /// </summary>
        IEnumerable<SolutionFileProjectFileReference> ListProjectFileReferences(SolutionFile solutionFile, string solutionFilePath);

        void AddSolutionFolder(SolutionFile solutionFile, string solutionFolderPath);

        bool HasSolutionFolder(SolutionFile solutionFile, string solutionFolderPath, out SolutionFileProjectReference solutionFolder);

        bool RemoveSolutionFolderAndContents(SolutionFile solutionFile, string solutionFolderPath);

        void MoveProjectFileIntoSolutionFolder(SolutionFile solutionFile, string solutionFilePath, string projectFilePath, string solutionFolderPath);

        void MoveProjectFileOutOfSolutionFolder(SolutionFile solutionFile, string solutionFilePath, string projectFilePath, string solutionFolderPath);

        IEnumerable<SolutionFileProjectFileReference> ListRootProjectFiles(SolutionFile solutionFile, string solutionFilePath);

        IEnumerable<SolutionFileProjectFileReference> ListSolutionFolderProjectFiles(SolutionFile solutionFile, string solutionFilePath, string solutionFolderPath);

        IEnumerable<SolutionFileProjectReference> ListRootSolutionFolders(SolutionFile solutionFile);

        IEnumerable<SolutionFileProjectReference> ListSolutionFolderSolutionFolders(SolutionFile solutionFile, string solutionFolderPath);
    }
}
