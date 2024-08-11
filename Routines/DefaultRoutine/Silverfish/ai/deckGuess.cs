using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREngine.Bots
{
    public class deckGuess
    {
        /// <summary>
        /// 常见套牌代码
        /// </summary>
        public static Dictionary<string, string> deckDatabase = new Dictionary<string, string>()
        {
            
            //  2021-09 标准天梯构筑
            // 萨满
            {"AAECAaoIAA/buAOTuQOYuQOn3gOo3gOq3gOM4QPg7APh7AOt7gPj7gOMnwSNnwT5nwT+nwQA", "暴风城元素打脸萨" },
            {"AAECAaoIAtb1A4CgBA7buAOq3gOr3gOM4QPg7APh7AOt7gOv7gPj7gPA9gPB9gOMnwT5nwTjoAQA", "暴风城元素萨" },
            {"AAECAaoIApzOA8L2Aw7buAPhzAPNzgPw1AOJ5AOK5APq5wP67APj7gPB9gPk9gPwhQT5nwT6nwQA", "暴风城FIVEKSRICK任务萨" },
            {"AAECAaoIBJzOA6jeA/rsA8L2Aw3buAOTuQPhzAP+0QPw1AOq3gOK5APq5wPj7gPB9gONnwT5nwT+nwQA ", "任务打脸萨" },
            // 术士
            {"AAECAf0GApXNA4T7Aw7LuQObzQPXzgPB0QPM0gOT3gO04QOT5AOU7gOI7wP9+gOD+wOEoATnoAQA", "暴风城任务动物园" },
            {"AAECAf0GCufwA9b5A9f5A6iKBLaKBIWgBJigBKOgBKmgBKqgBArDzAOO5wPThQSsnwSEoASPoAThoATnoATooATpoAQA", "暴风城大王术" },
            {"AAECAf0GApXNA4T7Aw61uQO2uQPLuQPXzgPB0QOT3gOV3gOT5AOI7wOK7wP9+gOB+wOD+wOEoAQA", "暴风城任务术" },
            {"AAECAf0GApTuA4T7Aw7LuQOVzQObzQPXzgPB0QPM0gOT3gO04QOT5AOI7wP9+gOD+wOEoATnoAQA", "暴风城任务黑眼园" },
            {"AAECAf0GBPLtA8f5A4T7A4f7Aw3XzgPB0QOL1QOT5APY7QPw7QPx7QOI7wPA+QPG+QOD+wOxnwTnoAQA ", "巨人任务术" },
            {"AAECAf0GCIT7A83SA4jvA/LtA/jjA8D5A4L7A7W5AwvXzgPr7QOS5AOxnwSD+wObzQPnoAST5APw7QPY7QPx7QMA ", "任务术" },
            // 法师
            {"AAECAf0EAuDMA+j3Aw7BuAOBvwPHzgPNzgP30QPU6gPQ7APR7AOn9wOu9wOy9wP8ngT9ngTonwQA", "暴风城任务法" },
            {"AAECAf0EApPhA/6eBA7BuAOMuQOBvwPgzAPHzgPNzgOU0QP30QP73QPr3gPQ7APR7AP8ngT9ngQA", "暴风城法术法" },
            {"AAECAf0EAA/3uAOVzQP43QP83QOM4QPS7AOt7gO/+QPH+QPK+QPO+QPQ+QP0/APVoATaoAQA", "暴风城谢幕法" },
            {"AAECAf0EArXJA+j3Aw7BuAPHzgPNzgP30QPU6gPQ7APR7AOn9wOu9wOy9wP0/AP8ngT9ngTonwQA ", "玛胖任务法" },
            // 战士
            {"AAECAQcEwd4DgeQDmPYD1vkDDeLMA+PMA/fUA7XeA/7nA9XxA5X2A5b2A5f2A8/7A6aKBK2gBK+gBAA=", "暴风城海盗战" },
            {"AAECAQcCle0DmPYDDuPMA4rQA/fUA7XeA4HkA/7nA9XxA5X2A5b2A5f2A8/7A6aKBK2gBK+gBAA=", "暴风城海盗战" },
            {"AAECAQcCmPYDsIoEDry5A4vQA/fUA7XeA/7nA5LoA47tA5TtA5X2A5b2A5f2A8/7A6aKBK2gBAA=", "暴风城海盗战" },
            {"AAECAQcEwN4Dle0DqooEsIoEDby5A+LMA93NA6fOA7PeA7XeA7reA8HeA8TeA/foA5jtA4j0A5X2AwA=", "暴风城健身战" },
            {"AAECAZfDAwr5wgO1yQOT0AO23gOq7gOP7wOU7wOY9gPY+QOmigQKuLkDtd4Dj+0D1fEDlfYDlvYDl/YDz/sD+IAEiKAEAA==", "防盗战" },
            {"AAECAQcK3r4DwN4Dwd4D+OgD1fED2fkDz/sDqIoEqooE1qAECuLMA93NA7XeA7reA77eA8TeA/TfA8fhA5jtA5X2AwA=", "马戏团瓦王战" },

            // 牧师
            {"AAECAa0GBOfwA7v3A9D5A62KBA2wugPpugObzQPXzgP7zgO70QOL1QO04QOh6AOI9wOj9wOt9wO9nwQA", "暴风城快攻暗牧" },
            {"AAECAa0GBPvRA+fwA7v3A62KBA2wugObzQPXzgO70QOL1QPK4wOh6AOK9AOI9wOj9wOt9wO9nwTvnwQA", "暴风城暗牧" },
            {"AAECAa0GBPvRA/zoA+fwA7v3Aw2wugPpugPevgObzQPXzgO70QOL1QPK4wOK9AOj9wOt9wOtigTvnwQA ", "卡扎暗牧" },
            {"AAECAa0GBOfRA/vRA+fwA7v3Aw2wugPevgObzQPXzgO70QPP0QOL1QPK4wOK9AOj9wOt9wPvnwTboAQA ", "主任暗牧" },
            {"AAECAa0GDMi+A9fOA/vRA53YA5vrA9TtA932A4b3A4j3A9D5A7WKBPCfBAmTugPezAPi3gP73wP44wOZ6wOe6wPz7gOH9wMA ", "控制牧" },
            {"AAECAa0GBsi+A86+A/vRA6bvA+fwA7v3AwzXzgPi3gP44wOW6AOb6wP08QOI9wOj9wOt9wPJ+QOtigS+nwQA ", "控制暗牧" },
            // 猎人
            {"AAECAR8E4c4Dj+MD5e8D5/ADDdzMA6LOA4LQA7nSA4biA8rjA9zqA5/sA/DsA9vtA/f4A6mfBLugBAA=", "暴风城enderT7猎" },
            {"AAECAR8C5/ADv6AEDqK5A/+6A9zMA6LOA4LQA7nSA4vVA7ThA4biA9zqA9vtA/f4A6mfBLugBAA=", "暴风城T7猎" },
            {"AAECAR8G5NQDj+MDj+QD5e8D/fgDl6AEDPvOA7nQA/7RA43kA5boA9zqA9vtA/f4A5T8A6mfBKqfBLugBAA=", "暴风城任务猎" },
            {"AAECAR8G5NQDj+MD5e8D/fgDlPwDl6AEDLnQA/7RA43kA5boA9zqA9vtA83yA/f4A6mfBKqfBOOfBLugBAA=", "任务猎" },
            // 骑士
            {"AAECAZ8FCPy4A/voA+PrA5HsA6L4A9j5A9n5A6qKBAvKwQOO1APM6wOH9AOI9APw9gPz9gON+AOq+APD+QPJoAQA", "暴风城圣盾骑" },
            {"AAECAZ8FAvvoA5HsAw7KwQO/0QPK0QOD3gOF3gPM6wPO6wPP6wPj6wPb7gOI9APw9gOVoATJoAQA", "暴风城铭枫奥秘骑" },
            {"AAECAZ8FCvy4A5XkA/voA5HsA6L4A6r4A8f5A9n5A6iKBKqKBArKwQPR0QPM6wPj6wOH9AOI9APw9gPz9gOVoATJoAQA", "暴风城驴哥污手骑" },
            {"AAECAZ3DAwr8uAO/0QOF3gP76APj6wOR7AOH9AOi+AOq+APH+QMKysEDytED++MD9+gD+OgDzOsDiPQD8PYDzfkDyaAEAA==", "哨所污手骑" },

            // 瞎子
            {"AAECAea5AwLn8APR9wMO2cYD+84D/tEDxd0DzN0D8+MDkOQDwvEDgIUEg58Etp8E0p8EsqAE7KAEAA==", "暴风城节奏蛋" },
            {"AAECAea5AwS/7QOv7wPQ+QPUnwQN2cYDi9UDyd0D194D8+MD9+gDmOoDu+0DvO0D/e0DqO8Di/cDgIUEAA==", "暴风城亡语瞎" },
            {"AAECAaOtBAT39gOL9wOw+QO2nwQN1tEDzNIDztID+dUD2d4D8+MD/e0DwvED9fYDivcD0PkDs6AEtKAEAA==", "任务瞎" },
            {"AAECAea5AwSXoATQ+QPR3QON9wMNx90DwvED8+MDivcDtp8EifcD3dMD6b4DlegDg58EmfkDjPcD2cYDAA==", "邪能瞎" },
            {"AAECAea5AwLQ3QON9wMO6b4D2cYD3dMDxd0Dx90D8+MDlegDwvEDifcDivcDg58Etp8EtKAE7KAEAA==", "邪能吸血瞎" },
            // 德鲁伊
            {"AAECAZICAozkA6P2Aw7lugPougPvugObzgOJ4AOK4AOi4QOk4QPR4QOK7QOk9gPR9gO4oAS5oAQA", "暴风城任务德" },
            {"AAECAZICAuTuA9efBA7lugPmugPougPvugObzgPw1AOJ4AOK4AOk4QPR4QOM5APA7AOunwTanwQA", "暴风城安娜德" },
            {"AAECAdfXAwa/4APR4QPk7gO1igSJnwS4oAQM5boD6LoDm84D8NQDieADiuADpOEDwOwDpPYDrp8E2p8EoKAEAA==", "克苏恩超凡德" },
            {"AAECAZICBJ3YA7/gA+TuA7WKBA3lugPmugPougObzgPw1AOJ4AOK4AOk4QPA7AOJnwSunwTanwSgoAQA ", "超凡中速德" },
            {"AAECAZICBNHhA5XkA7f3A6iKBA3kugPougObzgO60AO80AOT0QPe0QPw1AP+2wOk4QP36APe7AOk9gMA ", "保镖德" },
            {"AAECAdfXAwSSzQPR0QOm4QPE+QMN174Dm84DudIDjOQD9+gDuewDku4DiPQDyfUD7PUD0fYDgfcDhPcDAA==", "超生德" },
            // 贼
            {"AAECAaIHAsPhA6b5Aw6qywOk0QPf3QPn3QPz3QOo6wOr6wOf9AOh9AOi9AOj9QOm9QP1nwT2nwQA", "暴风城任务贼" },
            {"AAECAaIHAtXUA8X5Aw6qywP+0QP31APi3QPn3QOp6wOq6wOs6wOt6wOO9AOh9AOSnwSUnwT3nwQA", "暴风城刀贼" },
            {"AAECAcKPBATgvgOV6AOh9AORnwQNzrkDqssDn80Dx84D590D890DqOsDq+sDrusD/u4DjvQD9p8E958EAA==", "联络人锁喉贼" },
            {"AAECAaIHBJXNA5/NA/zoA+fwAw3evgPgvgOqywPHzgOk0QPf3QPn3QPz3QOo6wOr6wP+7gOO9AP2nwQA", "站场锁喉贼" },

            
            // 2021-09 狂野天梯构筑
            // 术士
            {"AAEBAf0GBN7EAoT7A4+CA87pAg3XzgOS5AP6/gLy0AKdqQPx9wKD+wObzQPnywL9pAOT5AO98QO1uQMA", "暴风城狂野气宗任务术" },
            {"AAEBAf0GBISgBIT7A4+CA8f5Aw3XzgOVzQP6/gLy0ALtrAPx9wKD+wObzQOT5APLuQOfzgLB0QPcCgA=", "暴风城狂野剑宗任务术" },
            {"AAEBAf0GCpLkA7GfBJ2pA+2sA4T7A4+CA+fLAvyjA87pAsMWCtfOA/r+AvLQAoP7A5vNA9/EAv2kA5PkA73xA7W5AwA=", "暴风城狂野宇宙术" },
            // 德鲁伊
            {"AAEBAZICAqP2A5vOAw65oASaCJjSAuED+a0DiuADuKAE5boD/M0CouEDwQSE5gLR9gNAAA==", "暴风城狂野口德" },
            {"AAEBAZICAp74AqP2Aw7pAeEDmgjoFb6rAvzNApjSAo/2AvmtA+W6A5vNA5vOA5XgA6LhAwA=", "暴风城狂野任务奇数德" },
            {"AAEBAZICBtaZA9ToA+TuA7CKBLQDtYoEDK6fBI/2AongA7/yAp7SAoTmAooOQNqfBKDNAsDsA4fOAgA=", "暴风城狂野超凡德" },
            {"AAEBAZICCPm1A9aZA9ToA4oO5O4DsIoEtAO1igQLrp8Ej/YCieADv/ICntIChOYCQNqfBKDNAsDsA4fOAgA=", "暴风城狂野超凡德" },
            {"AAEBAZICCLQDm+gCv/IC1pkD26UD5roDj84D5O4DC0CHzgKe0gKE5gKP9gKEtgObzgPw1AOK4APA7APanwQA", "暴风城狂野蓝龙德" },
            {"AAEBAZICAvcDkbwCDtQF5QeIDugVzbsC+60D6bAD3MwDxtEDudIDjOQD7PUD9PYDhPcDAA==", "暴风城狂野巨化德" },
            // 猎人
            {"AAEBAR8C/fgDnvgCDqqfBIAHjQHy4QPpqwK50APslgOH+wKpnwTb7QP3+AOoAs4U2wkA", "暴风城狂野走A猎" },
            {"AAEBAR8CnvgC/fgDDo0BqALtBoAHlwjbCbQTzhTpqwKH+wLslgO50APb7QP3+AMA", "暴风城狂野奇数走A猎" },
            // 法师
            {"AAEBAf0EAvSrA8sEDsiHA/T8A673A4XkA/fRA7L3A7T8AuYE/J4EwAHBuAPaxQLR7AOz9wMA", "暴风城狂野点燃法" },
            {"AAEBAf0EApLLA6iKBA6sAZ+bA/SrA4XkA/fRA5YFtPwC0OwD5gT8ngTLBMABwbgD0ewDAA==", "暴风城狂野决斗法" },
            {"AAEBAf0EBMABwfADkOEDleEDDeu6AvSrA76kA8agBPcN17YC558Ej9MC7AWR4QP9ngTdqQOHvQIA", "暴风城狂野奥秘法" },
            // 骑士
            {"AAEBAZ8FAA/b7gOD3gOMAcmgBNagBPfoA8rBA7EIiA7O6wOr7AOnBZqfBPjSAvvjAwA=", "暴风城狂野厕所骑" },
            {"AAEBAZ8FBJ74Ao6aA7/RA4PeAw3sD+0PuMcCjK0Dlc0Dm80DhN4DzOsD4+sDivQDx/kDx6AEyaAEAA==", "暴风城狂野奇数骑" },
            {"AAEBAZ8FBvoOk9ADi9UD++gDkewDx/kDDLoT97wC99AC2f4ClaYDysEDlc0DkeQDzOsD4+sD8PYD8/YDAA==", "暴风城狂野污手骑" },
            {"AAEBAZ8FBOAFhBf8uAPD0QMN4wWnCNOqArPBArHCAvz8ApupA8qrA/u4A/TfA5ToA/foA875AwA=", "暴风城狂野鱼人骑" },
            {"AAEBAZ8FBPoOh94DtPYDrooEDe0PuMcC2f4ClaYDlc0Dm80Dns0Dgt4DzOsD4+sDlfkDx6AEyaAEAA==", "暴风城狂野任务骑" },
            // 牧师
            {"AAEBAa0GBJG8ApvNA/vRA7v3Aw3XzgPlB5EP1AWt9wOhBOmwA9HBAvTxA/sPrYoEo/cDurYDAA==", "暴风城狂野海盗暗牧" },
            {"AAEBAa0GArW7Aof3Aw7RwQLwzwKp4gLmiAPvkgOspQOZqQO0tgPLzQPXzgP73wP44wP08QPT+QMA", "暴风城狂野野猪牧" },
            {"AAEBAa0GHh7DFoO7ArW7Are7Ati7AtHBAt/EAvDPAujQApDTAvLsApeHA+aIA+ubA/yjA5mpA8i+A9fOA/vRA+LeA/vfA/jjA5nrA5vrA9TtA/LuA932A6iKBMGfBAAA", "暴风城狂野宇宙牧" },
            {"AAEBAa0GBtMK8M8C/N8D+OMD3fYDzPkDDPoR0cEC5cwCtM4C4+kCl4cDmakD8qwDk7oD87sD4t4D+t8DAA==", "暴风城狂野大哥牧" },
            // 萨满
            {"AAEBAaoIAsL2A/oPDp79AvDUA/bwAvCFBPmfBIX6A/rsA9IT1g/hzAO8FLIG4AaMhQMA", "暴风城狂野任务萨" },
            {"AAEBAaoIBIQXqO4DxtED4AUN26AE2wPKqwOV8AO1mAOLzgKU6AOdwgKz6AOMlAOnCN3sA78XAA==", "暴风城狂野鱼人萨" },
            {"AAEBAaoIBpG8AovOAu/3ArWYA6juA+P2AwzUBe4G5Qf6qgL2vQL5vwLYqQPosAPduAPw1AOq3gPj7gMA", "暴风城狂野进化萨" },
            {"AAEBAaoIAvbwAvrsAw7gBtYP0hPKFp79AoyFA/aKA9u4A+HMA/DUA6reA+rnA4X6A/mfBAA=", "暴风城狂野快攻萨" },
            {"AAEBAaoIBovOArWYA6veA6juA8H2A4b6Awyw8AKq3gOM4QPg7APh7AOt7gOv7gPj7gOU8APW9QPA9gOMnwQA", "暴风城狂野元素萨" },
            {"AAEBAaoIBKirAt+pA8L2A/CFBA3OD9YP0hPz5wKf/QKMhQPbuAOTuQPzuwPw1AP67AOF+gP5nwQA", "暴风城狂野任务大哥萨" },
            {"AAEBAaoIHrIG+g7DFva9At/EApvLAovOAqvnAu/xAsXzAu/3AoyFA7WYA8OdA9qdA6GhA+GoA9u4A+S4A5O5A+DMA5vNA/DUA7/gA5jqA6juA+PuA6bvA8H2A/CgBAAA", "暴风城狂野宇宙战吼克萨" },
            // 战士
            {"AAEBAQcEkbwCmPYD3q0DxRUN5Qf+5wOCsALdrQPUBf8DpooElfYD6bAD+w+IsAKvoATuBgA=", "暴风城狂野海盗战" },
            {"AAEBAQcKhRe+wwLfxALTxQKgzgKa7gKb8wKS+AKT0AOd2AMKS6IE+Af/B+UPjs4Cz+cC2a0DitADju0DAA==", "暴风城狂野无限战" },
            {"AAEBAQcGhRferQOT0AOq7gOP7wOY9gMMkAOOzgKd8ALdrQOktgOcuwO13gPV8QPG9QOV9gOX9gOHoAQA", "暴风城狂野任务无限战" },
            {"AAEBAQcM/weS+AKe+ALerQOIsQPjvgP2wgP5wgOK0AOT0API4QOS5AMJqRWCrQLK5wKz/ALZrQOktgO4uQOIoASJoAQA", "暴风城狂野奇数防战" },
            {"AAEBAQcE+g6ggAOT0AOqigQNjRCSEJvLAp3wAqSkA5XNA7XeA8/eA47tA5jtA5rtA4j0A5X2AwA=", "暴风城狂野墙战" },
            // 瞎子
            {"AAEBAea5AwKSBZ74Ag7SnwT9pwPUyAOC0APC8QPz4wPczAO2E/LJA/X4A+C8A83dA+ygBM/dAwA=", "暴风城狂野奇数瞎" },
            {"AAEBAea5AwKSBZ74Ag62E/2nA+C8A9TIA/LJA9zMA4LQA83dA8/dA/PjA8LxA/X4A9KfBOygBAA=", "暴风城狂野亡语瞎" },
            // 贼
            {"AAEBAaIHCtIDrwT6DpG8ApfBAp74AuLdA/PdA/T2A+6gBArUBZsVubgDqssDm80DiNADpNED99QDkp8ElJ8EAA==", "暴风城狂野奇数贼" },
            {"AAEBAaIHBtQFkbwCu+8C4t0DrOsDofkDDMsD7gaIB68QmxXl0QLVjAOqywP31APz3QOq6wP3nwQA", "暴风城狂野弑君贼" },
            {"AAEBAaIHBMPhA53wA6H0A5afBA29BPW7AtvjAt/jApfnArSGA9/dA+LdA+fdA/7uA5GfBPafBPefBAA=", "暴风城狂野鬼灵贼" },


            // 经典套牌
            // 德鲁伊
            {"AAEDAZICArehBNuhBA7ZlQTblQTclQSvlgSwlgTdlgT6oASvoQTpoQTwoQTxoQSTogS9owTFqgQA", "经典咆哮德" },
            {"AAEDAZICBrWhBK+hBK+WBNuhBLehBK2hBAzdlgTclQTpoQTUogTZlQSwlgTxoQTblQSTogTwoQTFqgS9owQA", "经典咆哮德" },
            // 猎人
            {"AAEDAR8E0pYE0aIEzJYE3KEEDYWWBIGhBL2hBNGWBKKjBMuiBMCWBLGXBNGhBM2iBPiWBM+iBKGWBAA=", "经典T7猎" },
            {"AAEDAR8EgqEE3KEE0aIEqKMEDYWWBJyWBJ2WBMCWBMqWBNGWBPiWBLGXBMyiBM2iBM+iBKKjBMOjBAA=", "经典中速猎" },
            // 法师
            {"AAEDAf0EBrWhBLGhBNeiBOeVBNmiBJGiBAz0oATllQTFowTilQTUlgThlQTklQSVogSXogTmlQSTogTzoAQA", "经典冰法" },
            {"AAEBAf0EArOWBLWhBA7hlQTilQTllQTmlQTolQShlgTplgT0oAS9oQTVoQSTogSgowS/owTDowQA", "经典打脸法" },
            // 骑士
            {"AAEDAZ8FArahBNyhBA6BoQSyoQSHlgSzlgS9oQS0oQSwogSpowTDowSsogSOlgSPlgSQlgS3ogQA", "经典摸腿骑" },
            {"AAEDAZ8FComWBIqWBI+WBO6WBLWhBNuhBK6iBLaiBMWjBNKjBAqOlgSQlgSvlgSzlgT6oAS+oQSTogS1ogSpowTEowQA", "经典奶骑" },
            {"AAEDAZ8FComWBIqWBI+WBLOWBO6WBLGhBNOhBK6iBLaiBNKjBAqOlgSQlgSvlgS+oQSTogS1ogTUogSpowTDowTEowQA", "经典中速骑" },
            // 贼
            {"AAEDAaIHBIahBLWhBKWjBNyhBA38lQTooQTnoQT4oATfoQT9lQTdoQT7lgT6oATclgTkoQSTogTUoQQA", "经典奇迹贼" },
            {"AAEDAaIHBIKWBPuWBIahBNyhBA38lQT9lQSnlgT4oASyoQTLoQTToQTVoQTdoQThoQTkoQSTogTUogQA", "经典中速贼" },
            // 萨满
            {"AAEDAaoIBLWhBOqVBNyhBN2iBA2yoQSHogS9oQSEogTulQT5lgTDowTVoQSJogTUogSFogSTogTtlQQA", "经典打脸萨" },
            {"AAEDAaoICLWhBMuhBNOhBIeiBI2iBN2iBJCjBL6jBAvtlQTulQSnlgTnlgT5lgSyoQSEogSJogSOogSTogTUogQA", "经典中速萨" },
            // 术士
            {"AAEDAf0GAruiBIKhBA7tlgSBoQSyoQSzlgSjogS/ogT7lQSuoQTuoQTDowTVlgTDoQTToQSdogQA", "经典动物园" },
            {"AAEDAf0GAsShBNyhBA73lQT7lQSulgSzlgTVlgTrlgTtlgSBoQSyoQS9oQTRoQShogTUogTDowQA", "经典冲锋园" },
            {"AAEDAf0GBvqgBLWhBNyhBKGiBKWiBNyiBAz3lQTrlgTtlgSCoQTAoQTCoQTJoQTToQTaoQSaogScogSqowQA", "经典手牌术" },
            {"AAEDAf0GCvWVBOuWBK+hBLWhBJiiBJqiBJ6iBKWiBNmiBNyiBAr3lQTtlgSCoQTAoQTCoQTJoQTToQTaoQScogSqowQA", "经典大王术" },
            // 战士
            {"AAEDAQcMuaIEr6EEk6IEwKIE1qIE26EEt6EEiqIExKIExqIEmKIE2aIECZiWBMOiBPOWBL6iBJ2jBJeWBLGhBP+WBLCXBAA=", "经典防战" },
            {"AAEDAQcE+6AEzqEE3KEEvaIEDZWWBJeWBJmWBKGWBK6WBLCXBL2hBNGhBMGiBMKiBJ6jBMKjBMajBAA=", "经典打脸战" },
            // 牧师
            {"AAEDAa0GDM2VBL6WBNmWBLmXBPqgBLehBNKhBNuhBJiiBKmiBNyiBK2jBAnLlQTQlQSvlgSAlwS3lwSAoQSXowSrowTEowQA", "经典环牧" },
        };

        /// <summary>
        /// 解析套牌码，匹配常见卡组
        /// </summary>
        /// <returns>猜测卡组名称，默认空字符串</returns>
        public static string guessEnemyDeck(Playfield p)
        {
            Hrtprozis.Instance.enemyDeckName = "";
            Hrtprozis.Instance.similarity = 50;
            foreach (var deck in deckDatabase)
            {
                int similarity = calSimilarity(deck.Key);
                // 相似度阈值
                if(similarity > Hrtprozis.Instance.similarity)
                {
                    Hrtprozis.Instance.similarity = similarity;
                    Hrtprozis.Instance.guessEnemyDeck = new Dictionary<string, int>();
                    // 以对手视角计算
                    Playfield enemyPlayField = new Playfield(p, true);
                    calDeck(deck.Key, enemyPlayField);
                    Hrtprozis.Instance.enemyDeckName = deck.Value;
                }
            }
            return Hrtprozis.Instance.enemyDeckName;
        }

        /// <summary>
        /// 计算套牌相似度,会和对手坟场和场面比对（仅可收藏卡牌）
        /// </summary>
        /// <param name="deck">卡牌代码</param>
        /// <returns>相似度,百分比形式</returns>
        public static int calSimilarity(string deck)
        {
            List<string> decks = new List<string>();

            // 解析卡组代码
            byte[] bytes = Convert.FromBase64String(deck);

            int i = 0;
            // 保留字节，始终为 0
            if (bytes[i++] != 0) return 0;
            // 版本号始终为 1
            if (bytes[i++] != 1) return 0;
            // 模式 1 狂野 2 标准 
            i++;
            // 英雄卡牌数量默认 1 
            int numHeros = bytes[i++];
            // 读取英雄
            for(int j = 0; j < numHeros; j++)
            {
                ulong result = 0;
                int length = 0;
                while (i < bytes.Length)
                {
                    var value = (ulong)bytes[i] & 0x7f;
                    result |= value << 7 * (length++);
                    if ((bytes[i++] & 0x80) != 0x80)
                        break;
                }
                // 可以在这里判断英雄职业，如果和当前职业不符直接退出
                if (CardDB.Instance.getCardDataFromDbfID(result + "").Class != (int)Hrtprozis.Instance.enemyHeroStartClass) return 0;
            }
            // 放入一张的卡牌
            int numOne = bytes[i++];
            for (int j = 0; j < numOne; j++)
            {
                ulong result = 0;
                int length = 0;
                while (i < bytes.Length)
                {
                    var value = (ulong)bytes[i] & 0x7f;
                    result |= value << 7 * (length++);
                    if ((bytes[i++] & 0x80) != 0x80)
                        break;
                }
                // 加入卡组
                decks.Add("" + result);
            }
            // 放入两张的卡牌
            int numTwo = bytes[i++];
            for (int j = 0; j < numTwo; j++)
            {
                ulong result = 0;
                int length = 0;
                while (i < bytes.Length)
                {
                    var value = (ulong)bytes[i] & 0x7f;
                    result |= value << 7 * (length++);
                    if ((bytes[i++] & 0x80) != 0x80)
                        break;
                }
                // 加入卡组
                decks.Add("" + result);
            }
            // 放入N张的卡牌(理论上应该是 0)
            int numMore = bytes[i++];
            for (int j = 0; j < numMore; j++)
            {
                ulong result = 0;
                int length = 0;
                while (i < bytes.Length)
                {
                    var value = (ulong)bytes[i] & 0x7f;
                    result |= value << 7 * (length++);
                    if ((bytes[i++] & 0x80) != 0x80)
                        break;
                }
                // 加入卡组
                decks.Add("" + result);
            }

            int maxCount = 0;
            int sameCount = 0;
            // 比对对手任务...话说这就已经可以直接确定了吧...
            if(Questmanager.Instance.enemyQuest.maxProgress != 1000)
            {
                CardDB.Card card = CardDB.Instance.getCardDataFromID(Questmanager.Instance.enemyQuest.Id);
                if (card.Collectable)
                {
                    if (decks.Contains(card.dbfId))
                        sameCount++;
                    maxCount++;
                }
            }
            // 武器
            if(Hrtprozis.Instance.enemyWeapon.Durability > 0)
            {
                CardDB.Card card = Hrtprozis.Instance.enemyWeapon.card;
                if (card.Collectable)
                {
                    if (decks.Contains(card.dbfId))
                        sameCount++;
                    maxCount++;
                }
            }
            // 比对场面上的卡
            foreach(Minion m in Hrtprozis.Instance.enemyMinions)
            {
                if (!m.handcard.card.Collectable) continue;
                if( decks.Contains(m.handcard.card.dbfId) )
                    sameCount++;
                maxCount++;
            }
            // 比对坟场
            foreach(var deckCard in Probabilitymaker.Instance.enemyGraveyard)
            {
                CardDB.Card card = CardDB.Instance.getCardDataFromID(deckCard.Key);
                if (!card.Collectable) continue;
                if (decks.Contains(card.dbfId))
                    sameCount++;
                maxCount++;
            }

            if (deck == "AAEBAaoIBIQXqO4DxtED4AUN26AE2wPKqwOV8AO1mAOLzgKU6AOdwgKz6AOMlAOnCN3sA78XAA==")
            {
               sameCount = 0;
                maxCount = 0;
                // 鱼人萨衍生物判断
                // 比对场面上的卡
                foreach (Minion m in Hrtprozis.Instance.enemyMinions)
                {
                    if (!m.handcard.card.Collectable) continue;
                    if (m.handcard.card.race == CardDB.Race.MURLOC || decks.Contains(m.handcard.card.dbfId))
                        sameCount++;
                    maxCount++;
                }
                // 比对坟场
                foreach (var deckCard in Probabilitymaker.Instance.enemyGraveyard)
                {
                    CardDB.Card card = CardDB.Instance.getCardDataFromID(deckCard.Key);
                    if (!card.Collectable) continue;
                    if (card.race == CardDB.Race.MURLOC || decks.Contains(card.dbfId))
                        sameCount++;
                    maxCount++;
                }
            }

            if (maxCount > 0)
            {
                return sameCount * 100 / maxCount;
            }
            return 0;
        }

        /// <summary>
        /// 记录套牌信息，对手下回合斩杀线
        /// </summary>
        /// <param name="deck">卡牌代码</param>
        public static void calDeck(string deck, Playfield p)
        {
            Hrtprozis.Instance.enemyDeckCode = deck;
            // 解析卡组代码
            byte[] bytes = Convert.FromBase64String(deck);

            int i = 3;
            // 英雄卡牌数量默认 1 
            int numHeros = bytes[i++];
            // 读取英雄
            for (int j = 0; j < numHeros; j++)
            {
                ulong result = 0;
                int length = 0;
                while (i < bytes.Length)
                {
                    var value = (ulong)bytes[i] & 0x7f;
                    result |= value << 7 * (length++);
                    if ((bytes[i++] & 0x80) != 0x80)
                        break;
                }
            }
            // 放入一张的卡牌
            int numOne = bytes[i++];
            for (int j = 0; j < numOne; j++)
            {
                ulong result = 0;
                int length = 0;
                while (i < bytes.Length)
                {
                    var value = (ulong)bytes[i] & 0x7f;
                    result |= value << 7 * (length++);
                    if ((bytes[i++] & 0x80) != 0x80)
                        break;
                }
                // 加入卡组
                Hrtprozis.Instance.guessEnemyDeck.Add(""+ result, 1);
            }
            // 放入两张的卡牌
            int numTwo = bytes[i++];
            for (int j = 0; j < numTwo; j++)
            {
                ulong result = 0;
                int length = 0;
                while (i < bytes.Length)
                {
                    var value = (ulong)bytes[i] & 0x7f;
                    result |= value << 7 * (length++);
                    if ((bytes[i++] & 0x80) != 0x80)
                        break;
                }
                // 加入卡组
                Hrtprozis.Instance.guessEnemyDeck.Add("" + result, 2);
            }
            // 放入N张的卡牌(理论上应该是 0)
            int numMore = bytes[i++];
            for (int j = 0; j < numMore; j++)
            {
                ulong result = 0;
                int length = 0;
                while (i < bytes.Length)
                {
                    var value = (ulong)bytes[i] & 0x7f;
                    result |= value << 7 * (length++);
                    if ((bytes[i++] & 0x80) != 0x80)
                        break;
                }
                // 加入卡组
                Hrtprozis.Instance.guessEnemyDeck.Add("" + result, 3);
            }


            // 武器
            if (Hrtprozis.Instance.enemyWeapon.Durability > 0)
            {
                CardDB.Card card = Hrtprozis.Instance.enemyWeapon.card;
                if (card.Collectable)
                {
                    if (Hrtprozis.Instance.guessEnemyDeck.ContainsKey(card.dbfId))
                    {
                        Hrtprozis.Instance.guessEnemyDeck[card.dbfId]--;
                        if (Hrtprozis.Instance.guessEnemyDeck[card.dbfId] < 0)
                        {
                            Hrtprozis.Instance.guessEnemyDeck.Remove(card.dbfId);
                        }
                    }
                }

            }
            if (Probabilitymaker.Instance.enemyGraveyard.ContainsKey(CardDB.cardIDEnum.SW_428t2))
            {
                // 古夫
                Hrtprozis.Instance.guessEnemyDeck.Add("67884", 1);
            }
            if (Probabilitymaker.Instance.enemyGraveyard.ContainsKey(CardDB.cardIDEnum.SCH_514))
            {
                if (Hrtprozis.Instance.guessEnemyDeck.ContainsKey("49018"))
                {
                    Hrtprozis.Instance.guessEnemyDeck["49018"]++;
                }else
                {
                    Hrtprozis.Instance.guessEnemyDeck.Add("49018", 1);
                }
            }

            // 比对坟场
            foreach (var deckCard in Probabilitymaker.Instance.enemyGraveyard)
            {
                CardDB.Card card = CardDB.Instance.getCardDataFromID(deckCard.Key);
                if (Hrtprozis.Instance.guessEnemyDeck.ContainsKey(card.dbfId))
                {
                    Hrtprozis.Instance.guessEnemyDeck[card.dbfId]-= deckCard.Value;
                    if (Hrtprozis.Instance.guessEnemyDeck[card.dbfId] < 0)
                    {
                        Hrtprozis.Instance.guessEnemyDeck.Remove(card.dbfId);
                    }
                }
                // TODO 特殊任务衍生卡
            }
            // 比对场面上的卡
            foreach (Minion m in Hrtprozis.Instance.enemyMinions)
            {
                if (Hrtprozis.Instance.guessEnemyDeck.ContainsKey(m.handcard.card.dbfId))
                {
                    Hrtprozis.Instance.guessEnemyDeck[m.handcard.card.dbfId]--;
                    if (Hrtprozis.Instance.guessEnemyDeck[m.handcard.card.dbfId] < 0)
                    {
                        Hrtprozis.Instance.guessEnemyDeck.Remove(m.handcard.card.dbfId);
                    }
                }
            }
            if (Hrtprozis.Instance.guessEnemyDeck.ContainsKey("8659"))
            {
                if (Hrtprozis.Instance.guessEnemyDeck.ContainsKey("49018"))
                {
                    Hrtprozis.Instance.guessEnemyDeck["49018"]++;
                }
                else
                {
                    Hrtprozis.Instance.guessEnemyDeck.Add("49018", 1);
                }
            }

            calDirectDmg(p);
        }

        /// <summary>
        /// 交换函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        /// <summary>
        /// 计算对手直伤伤害
        /// 只计算对手打出手牌一半（向上取整）可能造成的最高伤害
        /// </summary>
        public static int calDirectDmg(Playfield enemyPlayField)
        {
            enemyPlayField.owncards = new List<Handmanager.Handcard>();
            foreach(var item in Hrtprozis.Instance.guessEnemyDeck)
            {
                CardDB.Card card = CardDB.Instance.getCardDataFromDbfID(item.Key);
                // 加入到对手可能的手牌数量
                for(int i = 0; i < item.Value; i++)
                {
                    enemyPlayField.owncards.Add(new Handmanager.Handcard(card) { manacost = card.cost});
                }
            }
            int nextTurnMana = enemyPlayField.ownMaxMana + 1;
            nextTurnMana = nextTurnMana > 10 ? 10 : nextTurnMana;
            // 最多计算对手手牌数量的一半（向上取整）
            int calMax = (enemyPlayField.enemyAnzCards+1) / 2 + (enemyPlayField.enemyAnzCards + 1) % 2;
            Hrtprozis.Instance.enemyDirectDmg = enemyPlayField.calDirectDmg(nextTurnMana, false, true, enemyPlayField.owncards.Count, calMax);
            return Hrtprozis.Instance.enemyDirectDmg;
        }
    }
}
