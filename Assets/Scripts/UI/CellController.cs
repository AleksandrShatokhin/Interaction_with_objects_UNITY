using UnityEngine;
using UnityEngine.UI;

public enum Value
{
    Default = 0,
    Apple = 1,
    Coin = 2,
    Booster = 3
}

public enum ChildInventory
{
    icon = 0,
    counter = 1
}

public enum StateCell
{
    StateDefault = 0,
    StateHaveItem = 1
}

public class CellController : InventoryManager
{
    [SerializeField] private int state;
    [SerializeField] private int value;

    private int counterDefault = 0;

    private Button buttonCell;
    private Image iconCell;
    private Text textCell;
    private int counter;

    private void Start()
    {
        // записываем необходимые компоненты €чеек инвентар€
        buttonCell = this.gameObject.GetComponent<Button>();
        iconCell = transform.GetChild((int)ChildInventory.icon).GetComponent<Image>();
        textCell = transform.GetChild((int)ChildInventory.counter).GetComponent<Text>();

        // обрабатываем необходимые операции
        buttonCell.onClick.AddListener(ClickCell);
        StateDefault();
    }

    public int StateDefault()
    {
        iconCell.sprite = iconDefault;
        textCell.text = counterDefault.ToString();
        textCell.color = Color.red;
        value = (int)Value.Default;

        return state = (int)StateCell.StateDefault;
    }

    public int StateHaveItem(Sprite icon, int counter, int value)
    {
        iconCell.sprite = icon;
        this.counter = counter;
        textCell.text = this.counter.ToString();
        textCell.color = Color.white;
        this.value = value;

        return state = (int)StateCell.StateHaveItem;
    }

    public void AddItemToCurrent(int counter)
    {
        this.counter += counter;
        textCell.text = this.counter.ToString();
    }

    private void ClickCell()
    {
        StateDefault();
    }

    public int GetState() => state;
    public int GetValue() => value;
}