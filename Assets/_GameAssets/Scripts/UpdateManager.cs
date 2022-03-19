using System.Collections;
using System.Collections.Generic;

public enum UpdateGroupName
{
    Realtime,
    Time2,
    Time5
}

public interface IUpdatable
{
    void OnUpdate();
}

public static class UpdateManager
{
    static Dictionary<UpdateGroupName, UpdateGroup> updateGroups = new Dictionary<UpdateGroupName, UpdateGroup>();
    static Dictionary<UpdateGroupName, bool> updateGroupsActive = new Dictionary<UpdateGroupName, bool>();
    
    public static void Update() {
        foreach (var group in updateGroups) {
            if (updateGroupsActive[group.Key]) {
                group.Value.Update();
            }
        }
    }

    public static void RegisterUpdateable(UpdateGroupName groupName, IUpdatable updatable) {
        updateGroups[groupName].OnUpdate += updatable.OnUpdate;
    }

    public static void UnregisterUpdateable(UpdateGroupName groupName, IUpdatable updatable) {
        updateGroups[groupName].OnUpdate -= updatable.OnUpdate;
    }

    //[RuntimeInitializeOnLoadMethod]
    public static void Init() {
        CreateGroup(UpdateGroupName.Realtime, 0.016f, true);
        CreateGroup(UpdateGroupName.Time2, 2f, true);
        CreateGroup(UpdateGroupName.Time5, 5f, true);
    }

    public static void CreateGroup(UpdateGroupName groupName, float delay, bool startActive) {
        updateGroups.Add(groupName, new UpdateGroup(delay));
        updateGroupsActive.Add(groupName, startActive);
    }
}