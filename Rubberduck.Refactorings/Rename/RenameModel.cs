﻿using System.Linq;
using Rubberduck.Parsing.Symbols;
using Rubberduck.Parsing.VBA.DeclarationCaching;
using Rubberduck.VBEditor;

namespace Rubberduck.Refactorings.Rename
{
    public class RenameModel : IRefactoringModel
    {
        private Declaration _target;
        public Declaration Target
        {
            get => _target;
            set
            {
                _target = value;
                NewName = _target.IdentifierName;
            }
        }

        public QualifiedSelection Selection { get; }
        
        public string NewName { get; set; }

        public RenameModel(DeclarationFinder declarationFinder, QualifiedSelection selection)
        {
            Selection = selection;

            AcquireTarget(out _target, declarationFinder, Selection);
        }

        private void AcquireTarget(out Declaration target, DeclarationFinder declarationFinder, QualifiedSelection selection)
        {
            target = declarationFinder.FindSelectedDeclaration(selection);
        }
    }
}
