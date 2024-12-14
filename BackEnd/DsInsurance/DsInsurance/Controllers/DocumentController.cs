using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public IActionResult GetAllDocuments()
        {
            var documents = _documentService.GetAllDocuments();
            return Ok(new
            {
                Message = "Documents retrieved successfully.",
                Data = documents
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetDocumentById(Guid id)
        {
            var document = _documentService.GetDocumentById(id);
            return Ok(new
            {
                Message = "Document retrieved successfully.",
                Data = document
            });
        }

        [HttpPost]
        public IActionResult AddDocument(DocumentDto documentDto)
        {
            var documentId = _documentService.AddDocument(documentDto);
            return Ok(new
            {
                Message = "Document added successfully.",
                DocumentId = documentId
            });
        }

        [HttpPut]
        public IActionResult UpdateDocument(DocumentDto documentDto)
        {
            _documentService.UpdateDocument(documentDto);
            return Ok(new
            {
                Message = "Document updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocument(Guid id)
        {
            _documentService.DeleteDocument(id);
            return Ok(new
            {
                Message = "Document deleted successfully."
            });
        }
    }
}
