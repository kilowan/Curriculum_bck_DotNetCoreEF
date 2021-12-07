﻿using curriculum.Data;
using Incidences.Models.Incidence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Incidences.Data
{
    public class NoteData //: INoteData
    {
        private readonly CurriculumContext _context;
        public NoteData(CurriculumContext context)
        {
            _context = context;
        }

        /*public Note SelectEmployeeNoteByIncidenceId(int incidenceId)
        {
            try
            {
                Notes note = _context.Notess
                    .Include(note => note.NoteType)
                    .Where(note => note.incidenceId == incidenceId)
                    .FirstOrDefault();
                if (note != null)
                {
                    return new(
                        note.noteStr, 
                        new NoteType() 
                        { 
                            Id = note.NoteType.id,
                            Name = note.NoteType.name
                        }, 
                        note.date);
                }
                else return new Note();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IList<Note> SelectNotesByIncidenceId(int incidenceId)
        {
            try
            {
                IList<Notes> notes = _context.Notess
                    .Include(note => note.NoteType)
                    .Where(note => note.incidenceId == incidenceId)
                    .ToList();

                IList<Note> result = new List<Note>();
                foreach (Notes note in notes)
                {
                    result.Add(
                        new(
                            note.noteStr,
                            new NoteType()
                            {
                                Id = note.NoteType.id,
                                Name = note.NoteType.name
                            },
                            note.date
                        )
                    );
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool UpdateNote(string note, int incidenceId, int employeeId)
        {
            try
            {
                Notes noteData = _context.Notess
                    .Where(note => note.incidenceId == incidenceId && note.employeeId == employeeId)
                    .FirstOrDefault();
                noteData.noteStr = note;
                _context.Notess.Update(noteData);
                if (_context.SaveChanges() != 1) throw new Exception("Nota no actualizada");

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool InsertNote(string note, int noteTypeId, int? ownerId, int? incidenceId)
        {
            try
            {
                int? old = _context.Notess
                    .Select(incidence => incidence.id)
                    .Max();
                if (old == null) old = 1;
                else old += 1;
                _context.Notess.Add(new Notes()
                {
                    noteStr = note,
                    noteTypeId = noteTypeId,
                    employeeId = (int)ownerId,
                    incidenceId = (int)incidenceId,
                    id = (int)old
                });
                if (_context.SaveChanges() != 1) throw new Exception("Nota no insertada");

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/
    }
}
