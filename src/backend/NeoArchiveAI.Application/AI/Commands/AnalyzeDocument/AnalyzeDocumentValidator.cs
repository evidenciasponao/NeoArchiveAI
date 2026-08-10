using FluentValidation;

namespace NeoArchiveAI.Application.AI.Commands.AnalyzeDocument;

public sealed class AnalyzeDocumentValidator
    : AbstractValidator<AnalyzeDocumentCommand>
{
    public AnalyzeDocumentValidator()
    {
        RuleFor(x => x.DocumentId)
            .NotEmpty();
    }
}
