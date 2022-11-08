﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces.Service;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly IPublicationService _publicationService;

        public PublicationController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        [HttpGet("get_all_publications")]
        public IEnumerable<PublicationModel> GetAllPublications()
        {
            return _publicationService.GetAllPublications();
        }

        [HttpGet("get_all_visible_publications")]
        public IEnumerable<PublicationModel> GetAllVisiblePublications()
        {
            return _publicationService.GetAllVisiblePublications();
        }

        [HttpGet("find_publication_by_id/{id}")]
        [ProducesResponseType(typeof(PublicationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPublicationById(int id)
        {
            var publication = _publicationService.GetPublicationById(id);
            return publication == null ? NotFound() : Ok(publication);
        }

        [HttpPost("create_publication")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreatePublication([FromBody] PublicationCreationModel publicationCreationModel)
        {
            var publication = _publicationService.CreatePublication(publicationCreationModel);
            return CreatedAtAction(nameof(GetPublicationById), new { id = publication.Id }, publication);
        }
    }
}
