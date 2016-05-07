using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Votr.Models
{
    public class Poll
    {
        public int PollId { get; set; }

        [MaxLength(500)]
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        
        // Need Options Relation
        
        public virtual List<Option> Options { get; set; }
        // Tag Relation
        // User Relation
        public virtual ApplicationUser CreatedBy { get; set; }
        // Vote Relation 
        /*
        public List<Tag> Tags()
        {
            
            List<Tag> tags = null;
            return tags;
        }

        public void AddTag(string some_tag_name)
        {
            // Get the tag
            PollTag pt = new PollTag {  Poll = this, Tag = some_tag}
        }
        */
    }
}