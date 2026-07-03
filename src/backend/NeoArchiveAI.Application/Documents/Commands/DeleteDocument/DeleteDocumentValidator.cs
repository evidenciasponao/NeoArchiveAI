using FluentValidation;

namespace NeoArchiveAI.Application.Documents.Commands.DeleteDocument;

public class DeleteDocumentValidator
    : AbstractValidator<DeleteDocumentCommand>
{
    public DeleteDocumentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}