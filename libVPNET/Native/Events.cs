﻿namespace VP.Native
{
    internal enum Events : int
    {
        Chat,
        AvatarAdd,
        AvatarChange,
        AvatarDelete,
        Object,
        ObjectChange,
        ObjectDelete,
        ObjectClick,
        WorldList,
        WorldSetting,
        WorldSettingsDone,  // Native: VP_EVENT_WORLD_SETTINGS_CHANGED
        Friend,             // Unused
        WorldDisconnect,
        UniverseDisconnect,
        UserAttributes,
        QueryCellEnd,
        TerrainNode,
        AvatarClick,
        Teleport,
        Url,
        ObjectBumpBegin,
        ObjectBumpEnd,
        Highest
    }
}
