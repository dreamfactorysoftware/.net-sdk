namespace DreamFactory.Model.Database
{
    /// <summary>
    /// Related schema.
    /// </summary>
    public class RelatedSchema
    {
        /// <summary>
        /// Name of the relationship.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Relationship type - belongs_to, has_many, many_many.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The table name that is referenced by the relationship.
        /// </summary>
        public string RefTable { get; set; }

        /// <summary>
        /// The field name that is referenced by the relationship. 
        /// </summary>
        public string RefField { get; set; }

        /// <summary>
        /// The intermediate joining table used for many_many relationships.
        /// </summary>
        public string Join { get; set; }

        /// <summary>
        /// The current table field that is used in the relationship.
        /// </summary>
        public string Field { get; set; }
    }
}
