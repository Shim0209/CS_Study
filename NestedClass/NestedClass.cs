using static System.Console;

/**
 * 중첩클래스는 자신이 소속된 클래스의멤버에 자유롭게 접근할 수 있다.
 * private 멤버에도 접근할 수 있다.
 * 
 * 중첩클래스를 사용하는 이유
 * 1. 클래스 외부에 공개하고 싶지 않은 형식을 만들고자 할 때
 * 2. 현재 클래스의 일부분처럼 표현할 수 있는 클래스를 만들고자 할 때
 */
namespace NestedClass
{
    class Configuration
    {
        List<ItemValue> listConfig = new List<ItemValue>();

        public void SetConfig(string item, string value)
        {
            ItemValue iv = new ItemValue();
            iv.SetValue(this, item, value);
        }

        public string GetConfig(string item)
        {
            foreach (ItemValue iv in listConfig)
            {
                if (iv.GetItem() == item)
                {
                    return iv.GetValue();
                }
            }
            return "";
        }

        // Configuration의 중첩클래스. private로 클래스 밖에서는 보이지 않음.
        private class ItemValue
        {
            private string item;
            private string value;

            public void SetValue(Configuration config, string item, string value)
            {
                this.item = item;
                this.value = value;

                bool found = false;

                // config.listConfig => 상위클래스 멤버에 자유롭게 접근
                for (int i=0; i<config.listConfig.Count; i++)
                {
                    if(config.listConfig[i].item == item)
                    {
                        config.listConfig[i] = this;
                        found = true;
                        break;
                    }
                }

                if(found == false)
                {
                    config.listConfig.Add(this);
                }
            }

            public string GetItem()
            {
                return item;
            }

            public string GetValue()
            {
                return value;
            }
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            config.SetConfig("Version", "V 5.0");
            config.SetConfig("Size", "655.324 KB");

            WriteLine(config.GetConfig("Version"));
            WriteLine(config.GetConfig("Size"));

            config.SetConfig("Version", "V 10.0");

            WriteLine(config.GetConfig("Version"));
        }
    }
}

