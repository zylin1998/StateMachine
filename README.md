# 狀態機 (StateMachine)

## 主旨

當單一物件需求多種的狀態，若集中在單一方法中進行判別，會導致可讀性降低極難以維護

```
public class Character : MonoBehaviour
{
  public float direct;
  public bool attack;
  public bool isGround;
  public bool isDead;

  public void Update()
  {
    if (direct == 0 && !isDead && isGround) { //Idle } 
    if (direct != 0 && !isDead && isGround) { //Move }
    if (attack && !dead && isGround) { //Attack }
    if (isDead) { //dead }
  }
}
```
當 ```Update``` 中進行判斷的動作愈多，程式可讀性及維護容易度都會變差，且每個判斷式在每次更新都會全部執行，導致效能變低且有多狀態同時執行的風險。狀態機的用途就是將狀態結構化，並儲存至狀態機，狀探機會根據當前狀態的輸出判斷，若可以離開則尋找可進入的狀態執行。
```
public class Character : MonoBehaviour
{
  public float direct;
  public bool attack;
  public bool isGround;
  public bool isDead;

  public IStateMachine machine;

  public void Awake()
  {
    var idle = StateMachine.FunctionalState()
      .EnterWhen(() => direct == 0 && !isDead && isGround)
      .DoTick(() => { //Idle });

    var move = StateMachine.FunctionalState()
      .EnterWhen(() => direct != 0 && !isDead && isGround)
      .DoTick(() => { //move });

    var attk = StateMachine.FunctionalState()
      .EnterWhen(() => attack && !isDead && isGround)
      .DoTick(() => { //Attack });

    var dead = StateMachine.FunctionalState()
      .EnterWhen(() => isDead)
      .ExitWhen(() => !isDead)
      .DoTick(() => { //Dead });

    machine = StateMachine.SingleEntrance()
      .WithState(idle, move, attk, dead);
  }

  public void Update()
  {
    machine.Transfer();

    machine.Tick();
  }
}
```
## 內容
### FunctionalState
自訂義狀態，可透過委派方法設定狀態
```
var state = StateMachine.FunctionalState()
  .EnterWhen(() => true)
  .ExitWhen(() => true)
  .DoOnEnter(() => { //OnEnter })
  .DoOnExit(() => { // OnExit })
  .DoTick(() => { //Update })
  .DoFixedTick(() => { //FixedUpdate })
  .DoLateTick(() => { //LateTick })
  .WithId(id);
```
```FunctionalState``` : 無觀察對象的狀態  
```FunctionalState<T1>``` : 單一觀察對象的狀態  
```FunctionalState<T1, T2>``` : 兩項觀察對象的狀態  
```FunctionalState<T1, T2, T3>``` : 三項觀察對象的狀態  
```FunctionalState<T1, T2, T3, T4>``` : 四項觀察對象的狀態  

### Entrance
```SingleEntrance``` : 單一入口狀態機，一次只容許單一狀態執行。  
```MultiEntrance``` : 多日口狀態機，可容許同時間可進入的所有狀態同時執行。  
```WithState``` : 可以新增狀態至狀態機

### Expand
#### 序列狀態機
```Sequence``` : 序列狀態機，會根據狀態的排列順序依序執行。  
```Orderby``` : 可以跟據輸入的 id 排序狀態的順序。  
```Cycle``` : 是否循環執行狀態。  
```Active``` : 狀態機是否處於活動中。  
```IgnoreEnter``` : 是否忽略進入點強制執行狀態。  
```
var state1 = StateMachine.FunctionalState().WithId(1);
var state2 = StateMachine.FunctionalState().WithId(2);
var state3 = StateMachine.FunctionalState().WithId(3);

var machine = StateMachine.SingleEntrance()
  .Sequence()
  .OrderBy(1, 2, 1, 3);
```
#### 階層狀態機
```Phase``` : 階層狀態機，可作為狀態使用，添加至其他狀態機。  
```Phase<T1>``` : 單一觀察對象的階層狀態機。  
```Phase<T1, T2>``` : 兩項觀察對象的階層狀態機。  
```Phase<T1, T2, T3>``` : 三項觀察對象的階層狀態機。  
```Phase<T1, T2, T3, T4>``` : 四項觀察對象的階層狀態機。  
```EnterWhen``` : 設定作為狀態時的進入點。  
```ExitWhen``` : 設定作為狀態時的出入點。  
```DoOnEnter``` : 設定作為狀態時的進入執行項目。  
```DoOnExit``` : 設定作為狀態時的出入執行項目。  
```WithId``` : 設定作為狀態時的 id 。
```
var machine = StateMachine.SingleEntrance()
  .Phase()
  .EnterWhen(() => true)
  .ExitWhen(() => true)
  .DoOnEnter(() => { //OnEnter })
  .DoOnExit(() => { //OnExit });
```
### Unity
```Update``` : 可讓狀態機以 Update 的方式執行。  
```FixedUpdate``` : 可讓狀態機以 FixedUpdate 的方式執行。  
```LateUpdate``` : 可讓狀態機以 LateUpdate 的方式執行。  
```AddTo``` : 可將進入更新模式後的```IDisposable```類別掛載至```GameObject```上。  
>任一更新模式執行後會回傳```IDisposable```類別，執行```Dispose```後會解除更新模式。
### Asset
#### StateAssetBase 
繼承 ```ScriptableObject``` 的類別，可繼承並實作```GetState```方法已取得狀態，包含從 0~4 種觀察對象的多載類別。
#### StateMachineAsset
繼承 ```ScriptableObject``` 的類別，可透過```GetMachine```方法取得狀態機，包含從 0~4 種觀察對象的多載類別。
#### PhaseStateMachineAsset
繼承 ```ScriptableObject``` 的類別，同時包含```GetState```即```GetMachine```方法，皆會取得 PhaseStateMachine ，包含從 0~4 種觀察對象的多載類別。
