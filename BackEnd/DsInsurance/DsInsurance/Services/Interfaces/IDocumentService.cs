using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IDocumentService
    {
        List<DocumentDto> GetAllDocuments();
        DocumentDto GetDocumentById(Guid documentId);
        Guid AddDocument(DocumentDto documentDto);
        void UpdateDocument(DocumentDto documentDto);
        void DeleteDocument(Guid documentId);
        public void AddBulkDocuments(List<DocumentDto> documentDtos);
    }
}
