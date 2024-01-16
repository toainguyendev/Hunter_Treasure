using System;

[Serializable]
public struct CommonUserDataModel : IDataModel<CommonUserDataModel>
{
    public int level;

    public void SetDefaultData()
    {
        level = 1;
    }
}
