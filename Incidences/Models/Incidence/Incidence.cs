﻿using System;
using System.Collections.Generic;

namespace Incidences.Models.Incidence
{
    public class Incidence
    {
        private string owner;
        private int? ownerId;
        private string solver;
        private int? solverId;
        private DateTime? initDateTime;
        private string issueDesc;
        private IList<Piece> pieces;
        private IList<Note> notes;
        private int? state;
        private int id;
        private DateTime? finishDateTime;

        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }
        public int? OwnerId
        {
            get
            {
                return ownerId;
            }
            set
            {
                ownerId = value;
            }
        }
        public string Solver
        {
            get
            {
                return solver;
            }
            set
            {
                solver = value;
            }
        }
        public int? SolverId
        {
            get
            {
                return solverId;
            }
            set
            {
                solverId = value;
            }
        }
        public DateTime? InitDateTime
        {
            get
            {
                return initDateTime;
            }
            set
            {
                initDateTime = value;
            }
        }
        public string IssueDesc
        {
            get
            {
                return issueDesc;
            }
            set
            {
                issueDesc = value;
            }
        }
        public IList<Piece> Pieces
        {
            get
            {
                return pieces;
            }
            set
            {
                pieces = value;
            }
        }
        public IList<Note> Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
        public int? State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public DateTime? FinishDateTime
        {
            get
            {
                return finishDateTime;
            }
            set
            {
                finishDateTime = value;
            }
        }

        public Incidence(int id, string owner, int ownerId, DateTime initDateTime, string issueDesc, int state, string solver, int? solverId, DateTime? FinishDateTime)
        {
            this.id = id;
            this.owner = owner;
            this.ownerId = ownerId;
            this.issueDesc = issueDesc;
            this.initDateTime = initDateTime;
            this.pieces = new List<Piece>();
            //this.pieces.Add(piece);
            this.notes = new List<Note>();
            //this.notes.Add(note);
            this.finishDateTime = null;
            this.state = state;
            this.solver = solver;
            this.solverId = solverId;
            this.finishDateTime = FinishDateTime;
        }
        public Incidence(int id, int state, string owner, int ownerId, DateTime initDateTime, string issueDesc, IList<Piece> pieces, IList<Note> notes)
        {
            this.id = id;
            this.state = state;
            this.owner = owner;
            this.ownerId = ownerId;
            this.issueDesc = issueDesc;
            this.initDateTime = initDateTime;
            this.pieces = pieces;
            this.notes = notes;
        }
        public Incidence(int id, int state, string owner, int ownerId, DateTime initDateTime, string issueDesc, IList<Piece> pieces, IList<Note> notes, DateTime finishDateTime)
        {
            this.id = id;
            this.state = state;
            this.owner = owner;
            this.ownerId = ownerId;
            this.issueDesc = issueDesc;
            this.initDateTime = initDateTime;
            this.pieces = pieces;
            this.notes = notes;
            this.finishDateTime = finishDateTime;
        }
        public void AddPiece(Piece piece)
        {
            this.pieces.Add(piece);
        }
        public void AddNote(Note note)
        {
            this.notes.Add(note);
        }
    }
}