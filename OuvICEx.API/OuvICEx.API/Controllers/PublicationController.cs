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

        [HttpGet]
        public IEnumerable<Publication> Get()
        {
            return _publicationService.GetAllPublications();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Publication), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicationById(int id)
        {
            var publication = await _publicationService.GetPublicationByIdAsync(id);
            return publication == null ? NotFound() : Ok(publication);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePublication(PublicationModel publicationModel)
        {
            var publication = await _publicationService.CreatePublicationAsync(publicationModel);
            return CreatedAtAction(nameof(GetPublicationById), new { id = publication.Id }, publication);
        }
    }
}