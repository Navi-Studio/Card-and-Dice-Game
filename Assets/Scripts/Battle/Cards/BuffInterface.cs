
public interface BuffInterface
{
   /**
     * Call at the start
     */
    public void OnBuffStart();
 
   /**
     * Call at the end
     */
    public void OnBuffEnd();
    
    /**
     * Polling at the end of each round end
     */
    public void OnBuffPerTurn();
    
    /**
     * Call at the end
     */
    public void TriggerBuff();
    
}
