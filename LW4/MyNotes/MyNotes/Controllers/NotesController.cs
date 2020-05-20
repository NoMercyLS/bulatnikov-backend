using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
using Newtonsoft.Json;

namespace MyNotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepository _notesRepository;
        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
            notesRepository.SetPath("Storage\\NotesList.txt");
        }

        [HttpGet("notes/list")]
        public IActionResult GetList()
        {
            var notes = _notesRepository.GetNotes();
            var json = JsonConvert.SerializeObject(notes, Formatting.Indented);
            return Content(json);
        }

        [HttpPost("note/add")]
        public async Task<StatusCodeResult> AddNote()
        {
            Note note = new Note();
            using (StreamReader content = new StreamReader(Request.Body, Encoding.UTF8))
            {
                note.content = await content.ReadToEndAsync();
            }
            _notesRepository.AddNote(note);
            return Ok();
        }
    }
}