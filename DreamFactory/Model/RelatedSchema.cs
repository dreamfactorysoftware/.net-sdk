// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    /// <summary>
    /// Related schema model.
    /// </summary>
    public class RelatedSchema
    {
        /// <summary>
        /// Name of the relationship.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Relationship type - belongs_to, has_many, many_many.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The table name that is referenced by the relationship.
        /// </summary>
        public string ref_table { get; set; }

        /// <summary>
        /// The field name that is referenced by the relationship. 
        /// </summary>
        public string ref_field { get; set; }

        /// <summary>
        /// The intermediate joining table used for many_many relationships.
        /// </summary>
        public string join { get; set; }

        /// <summary>
        /// The current table field that is used in the relationship.
        /// </summary>
        public string field { get; set; }
    }
}
