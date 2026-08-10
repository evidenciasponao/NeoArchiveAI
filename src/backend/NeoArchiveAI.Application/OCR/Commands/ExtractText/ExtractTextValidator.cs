using FluentValidation;

namespace NeoArchiveAI.Application.OCR.Commands.ExtractText;

public sealed class ExtractTextValidator
    : AbstractValidator<ExtractTextCommand>
{
    public ExtractTextValidator()
    {
        RuleFor(x => x.DocumentId)
            .NotEmpty()
            .WithMessage("Document Id is required.");
    }
}
