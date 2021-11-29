﻿using Incidences.Data;
using Incidences.Models.Incidence;
using Incidences.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Incidences.Business
{
    public class PieceBz : IPieceBz
    {
        #region cconstants
        //tables
        private const string piece_class = "piece_class";
        private const string ipl = "incidence_piece_log";
        private const string FullPiece = "FullPiece";

        //columns
        private const string typeId = "typeId";
        private const string nameC = "name";
        private const string status = "status";
        private const string deletedC = "deleted";
        private const string pieceId = "pieceId";
        private const string incidenceIdC = "incidenceId";
        private const string ALL = "*";

        #endregion

        private readonly IBusinessBase bisba;
        private readonly ISqlBase sql;
        public PieceBz(IBusinessBase bisba, ISqlBase sql)
        {
            this.bisba = bisba;
            this.sql = sql;
        }
        public bool InsertPiece(PieceDto piece)
        {
            try
            {
                return this.sql.Insert(piece_class, new()
                {
                    { typeId, null, piece.typeId.ToString() },
                    { nameC, null, piece.name }
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool AddPieceFn(PieceDto piece)
        {
            try
            {
                return InsertPiece(piece);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool InsertPiecesSql(IList<int> pieces, int incidenceId)
        {
            try
            {
                IList<string> values = new List<string>();
                foreach (int piece in pieces)
                {
                    values.Add($"{piece}, {incidenceId}");
                }
                string stringPieces = string.Join(", ", values);
                string text = $"INSERT INTO {ipl} ({pieceId}, {incidenceIdC}) VALUES ({ stringPieces });";
                return this.sql.Call(text);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeletePiecesSql(IList<int> pieces, int incidenceId)
        {
            try
            {

                CDictionary<string, string> conditions;
                if (pieces.Count > 1) conditions = this.bisba.WherePieceId(new CDictionary<string, string>(), pieces);
                else conditions = this.bisba.WherePieceId(new CDictionary<string, string>(), pieces[0]);

                
                bool result = this.sql.Update(
                    ipl,
                    new CDictionary<string, string> {
                        { status, null, "1" }
                    },
                    conditions
                );

                this.sql.Close();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeletePiece(int id)
        {
            try
            {
                bisba.WhereId(new CDictionary<string, string>(), id);
                return this.sql.Update(
                    piece_class, 
                    new CDictionary<string, string> { 
                        { deletedC, null, "1" } 
                    },
                    bisba.WhereId(new CDictionary<string, string>(), id)
                );
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public CDictionary<string, string> GetPieceColumns(int type, string name, bool deleted)
        {
            CDictionary<string, string> columns = new()
            {
                { typeId, null, type.ToString() },
                { nameC, null, name },
                { deletedC, null, deleted.ToString() }
            };

            return columns;
        }
        public bool UpdatePiece(PieceDto piece, int id)
        {
            try
            {
                return this.sql.Update(
                    piece_class,
                    GetPieceColumns(piece),
                    this.bisba.WherePieceId(new CDictionary<string, string>(), id));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool UpdatePiece(int id, bool deleted)
        {
            try
            {
                bool result = this.sql.Update(piece_class,
                    new()
                    {
                        { deletedC, null, deleted.ToString() }
                    },
                    this.bisba.WherePieceId(
                        new CDictionary<string, string>(),
                        id
                    )
                );

                this.sql.Close();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private Piece SelectPieceById(int pieceId)
        {
            try
            {
                IList<Piece> pieces = SelectPieces(
                    this.bisba.WherePieceId(
                        new CDictionary<string, string>(), 
                        pieceId
                    )
                );
                return pieces[0];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private IList<Piece> SelectPieces(CDictionary<string, string> conditions = null)
        {
            try
            {
                bool result = this.sql.Select(new Select(FullPiece, new List<string> { ALL }, conditions));
                if (result)
                {
                    IList<Piece> pieces = new List<Piece>();
                    using IDataReader reader = this.sql.GetReader();
                    while (reader.Read())
                    {
                        pieces.Add(new(
                            (int)reader.GetValue(0),
                            (string)reader.GetValue(1),
                            new PieceType(
                                (int)reader.GetValue(2),
                                (string)reader.GetValue(3),
                                (string)reader.GetValue(4)
                            ),
                            Convert.ToBoolean(reader.GetValue(5))
                        ));
                    }

                    this.sql.Close();
                    return pieces;
                }
                else throw new Exception("Ningún registro");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeletePieceFn(int id)
        {
            try
            {
                return UpdatePiece(id, true);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IList<Piece> GetPieces(int? piece = null)
        {
            try
            {
                CDictionary<string, string> conditions;
                if (piece != null)
                {
                    conditions = this.bisba.WherePieceId(
                        this.bisba.WhereNotDeleted(
                            new CDictionary<string, string>()
                            ), 
                        piece
                    );
                }
                else
                {
                    conditions = this.bisba.WhereNotDeleted(
                        new CDictionary<string, string>()
                    );
                }

                return SelectPieces(conditions);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public CDictionary<string, string> GetPieceColumns(PieceDto piece)
        {
            CDictionary<string, string> tmpColumns = new CDictionary<string, string>();
            if (piece.typeId != null) tmpColumns.Add(typeId, null, piece.typeId.ToString());
            if (piece.name != null) tmpColumns.Add(nameC, null, piece.name);
            if (piece.deleted != null) tmpColumns.Add(deletedC, null, piece.deleted.ToString());
            return tmpColumns;
        }
    }
}
