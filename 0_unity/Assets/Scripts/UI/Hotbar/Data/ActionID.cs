
namespace UI.Hotbar.Data
{
    
    public class ActionID
    {
        private uint? _ID = null;

        public ActionID(uint ID)
        {
            this._ID = ID;
        }

        public override string ToString()
        {
            return _ID.ToString();
        }
    }
}