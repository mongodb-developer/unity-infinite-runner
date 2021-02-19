using Realms;

public class PlayerStats : RealmObject {
    
    [PrimaryKey]
    public string Username { get; set; }

    public RealmInteger<int> Score { get; set; }
    public RealmInteger<int> Cake { get; set; }

    public PlayerStats() {}

    public PlayerStats(string Username) {
        this.Username = Username;
    }

}
