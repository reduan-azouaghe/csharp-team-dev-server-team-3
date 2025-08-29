namespace exercise.wwwapi.Helpers
{
    public class Validator
    {
        public bool Password(string passwordString)
        {
            //TODO: Not less than 8 characters       | Done
            //TODO: Atleast one uppercase            | 
            //TODO: Atleast one number               |
            //TODO: Atleast one special character    |

            if (passwordString.Count() < 8) return false;
            if (!passwordString.Any(char.IsUpper)) return false;
            if (!passwordString.Any(char.IsNumber)) return false;
            if (!passwordString.Any(char.is)) return false;
        }
    }
}
