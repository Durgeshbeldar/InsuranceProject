using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository<Document> _documentRepository;
        private readonly IMapper _mapper;

        public DocumentService(IRepository<Document> documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public List<DocumentDto> GetAllDocuments()
        {
            var documents = _documentRepository.GetAll().ToList();
            if (!documents.Any())
                throw new NotFoundException("Documents");

            return _mapper.Map<List<DocumentDto>>(documents);
        }

        

        public DocumentDto GetDocumentById(Guid documentId)
        {
            var document = _documentRepository.GetById(documentId);
            if (document == null)
                throw new NotFoundException("Document");

            return _mapper.Map<DocumentDto>(document);
        }

        public Guid AddDocument(DocumentDto documentDto)
        {
            var document = _mapper.Map<Document>(documentDto);
            _documentRepository.Add(document);
            return document.DocumentId;
        }

        public void UpdateDocument(DocumentDto documentDto)
        {
            var updatedDocument = _mapper.Map<Document>(documentDto);
            var existingDocument = _documentRepository.GetAll().AsNoTracking().FirstOrDefault(doc => updatedDocument.DocumentId == doc.DocumentId);
            if (existingDocument == null)
                throw new NotFoundException("Document");

            _documentRepository.Update(updatedDocument);
        }

        public void DeleteDocument(Guid documentId)
        {
            var document = _documentRepository.GetById(documentId);
            if (document == null)
                throw new NotFoundException("Document");

            document.IsVerified = false; // Soft Delete (Optional)
            _documentRepository.Update(document);
        }

        public void AddBulkDocuments(List<DocumentDto> documentDtos)
        {
            if (documentDtos == null || !documentDtos.Any())
                throw new ArgumentException("Document list is empty");

            var documents = _mapper.Map<List<Document>>(documentDtos);

            // Bulk Insert for better performance
            _documentRepository.AddRange(documents);
        }
    }
}
