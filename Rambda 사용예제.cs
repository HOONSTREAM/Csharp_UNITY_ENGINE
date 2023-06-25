using System.Runtime.CompilerServices;

namespace Rambda_람다식_사용예제
{
    class Program
    {
        enum ItemType
        {
            Weapon,
            Armor,
            Amulet,
            Ring
        } 
        enum Rarity
        {
            Normal,
            Uncommon,
            Rare
        }

        class Item
        {
            public ItemType itemtype;
            public Rarity rairty;

        }

       static List<Item> items = new List<Item>();
        delegate bool Itemselector(Item item);
      
        static Item FindWeapon()
        {
            foreach (var item in items) {
            
                if(item.itemtype == ItemType.Weapon)
                {
                    return item;
                }

            }

            return null;
        }
        static void Main(string[] args)
        {
            items.Add(new Item() {itemtype = ItemType.Weapon,rairty = Rarity.Normal});
            items.Add(new Item() { itemtype = ItemType.Armor, rairty = Rarity.Uncommon });
            items.Add(new Item() { itemtype = ItemType.Amulet, rairty = Rarity.Rare });

            //무명함수(Anonymous Function)
          
            Func<Item,bool> FindItem = (Item item) => { return item.itemtype == ItemType.Weapon; }; //람다식
            //델리게이트를 이용하여 정의 가능하지만, 한번쓰고 버릴것이라면 단순히 람다식을 이용하여 정의한 후 버린다. (코드줄임 -> 가독성)
            //delegate를 만들어두지 않아도 이미 만들어진 함수가 존재
            //반환타입이 있을경우 Func
            //반환타입이 없을경우 Action



        }
    }
}