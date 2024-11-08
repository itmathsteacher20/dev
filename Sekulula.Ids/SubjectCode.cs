namespace Sekulula.Contracts.Subjects
{
    public class SubjectCode(int subjCode)
    {
        public int Value {get; init;} = IsValidCode(subjCode) ? subjCode : throw new InvalidIdentifierException("", nameof(subjCode));
        
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"SubjectCode: {Value} "
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is int) return (int)obj == Value;
            if (obj is not SubjectCode) return false;
            if (obj is SubjectCode code)
            {
                return code.Value == Value;
            }
            return false;
        }

        public static bool operator ==(SubjectCode left, SubjectCode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SubjectCode left, SubjectCode right)
        {
            return !(left == right);
        }

        public static implicit operator int(SubjectCode code)
        {
            return Value;
        }

        private static bool IsValidCode(int theCode)
        {
            List<int> spcCodes = [];
            List<int> jcCodes = [];
            List<int> sgcseCode = [];

            if (spcCodes.Any(code=> theCode == code)) return true;

            if (jcCodes.Contains(theCode)) return true;

            if (sgcseCode.Contains(theCode)) return true;

            return false;
        }
    }

    public sealed class InvalidIdentifierException(string msg, string paramName):InvalidArgumentException(msg, paramName) {}
}