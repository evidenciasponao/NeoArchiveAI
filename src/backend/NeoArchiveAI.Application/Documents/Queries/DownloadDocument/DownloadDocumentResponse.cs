using System.IO;

namespace NeoArchiveAI.Application.Documents.Queries.DownloadDocument;

public sealed record DownloadDocumentResponse(
    Stream Content,
    string FileName,
    string ContentType
);
