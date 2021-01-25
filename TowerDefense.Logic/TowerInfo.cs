namespace TowerDefense.Logic
{
    public class TowerInfo
    {
        public readonly int _towerId;
        public readonly string _towerTypecode;
        public readonly string _towerName;
        public readonly string _prefabPath;
        public readonly float _range;
        public readonly float _startTime;
        public readonly float _updateTargetRate;
        public readonly float _fireRate;
        public readonly float _fireCooldown;

        public TowerInfo(int towerId, string towerTypeCode, string towerName, string prefabPath,
                         float range, float startTime, float updateTargetRate, float fireRate, float fireCooldown)
        {
            _towerId = towerId;
            _towerTypecode = towerTypeCode;
            _towerName = towerName;
            _prefabPath = prefabPath;
            _range = range;
            _startTime = startTime;
            _updateTargetRate = updateTargetRate;
            _fireRate = fireRate;
            _fireCooldown = fireCooldown;
        }
    }
}