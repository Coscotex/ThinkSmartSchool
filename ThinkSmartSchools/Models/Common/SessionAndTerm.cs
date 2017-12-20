using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkSmartSchools.Models.Common
{
    public class SessionAndTerm
    {
        private readonly ForSchoolsDBContext _context;

        public SessionAndTerm(ForSchoolsDBContext context)
        {
            _context = context;
        }

        public SessionTerm GetSessionTerm(int sessionID, int termID, int institutionID)
        {
            return _context.SessionTerm.FirstOrDefault(e => e.SessionId == sessionID && e.TermId == termID && e.InstitutionId == institutionID);
        }

        public SessionTerm GetCurrentSessionTerm(int institutionID)
        {
            int currentSessionID = _context.Session.FirstOrDefault(g => g.Status == true).Id;
            int currentTermID = _context.Term.FirstOrDefault(g => g.Status == true && g.InstitutionId == institutionID).Id;
            return _context.SessionTerm.FirstOrDefault(e => e.SessionId == currentSessionID && e.TermId == currentTermID && e.InstitutionId == institutionID);
        }
    }
}
