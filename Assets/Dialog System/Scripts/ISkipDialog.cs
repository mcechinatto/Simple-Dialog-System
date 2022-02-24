//Implement this to create a monobehaviour that contains logic to skip a dialog
public interface ISkipDialog
{
   System.Action SkipDialog { get; set; }
}
