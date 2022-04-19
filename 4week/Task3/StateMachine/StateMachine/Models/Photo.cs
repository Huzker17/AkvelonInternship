using System;
using System.Net;

namespace StateMachine.Models
{
    public class Photo
    {
        //    [CompilerGenerated]
        //    private sealed class <Download>d__0 : IAsyncStateMachine
        //    {
        //        В первой переменной <>1_state сохраняется номер достигнутого оператора await.
        //        Пока не встретился никакой await, значение этой переменной равно -1.
        //        Все операторы await в оригинальном методе пронумерованы, и в момент приостановки
        //        в переменную state заносится номер await, после которого нужно будет возобновить исполнение.

        //        public int <>1__state;


        //        Это построитель для асинхронных методов, которые возвращают задачу.
        //        Этот вспомогательный тип и его члены предназначены для использования компилятором.
        //        Здесь инкапсулирована логика, общая для всех конечных автоматов.Именно этот тип создает объект Task,
        //        возвращаемых заглушкой и ради повышения производительности является структурой, а не классом.

        //        public AsyncTaskMethodBuilder<> t__builder;


        //        Является входным параметром и не переиспользуется в метаданных, так как это Immutable type,
        //        и state_machine не надо использовать копию, так как стринг не меняется и является ссылочным типом

        //        public string fireUrl;


        //        Данная переменная встречается только в конечных автоматах для нестатических асинхронных методов и содержит объект,
        //        от имени которого он вызывался. В каком-то смысле this — это просто еще одна локальная переменная метода,
        //        только она используется для доступа к другим переменным членам того же объекта.
        //        В процессе преобразования async-метода ее необходимо сохранить и использовать явно,
        //        потому что код оригинального объекта перенесен в структуру конечного автомата.

        //        public Downloader<>4__this;


        //        Следующая переменная <uri>5__1 служит для хранения оригинальной переменной one.
        //        В генерированном компилятором коде все обращения к этой переменной заменены на обращение к этой переменной-члену.

        //        private Uri<uri>5__1;


        //      Следующая переменная <myWebClient>5__2 служит для хранения оригинальной переменной one.
        //      В генерированном компилятором коде все обращения к этой переменной заменены на обращение к этой переменной-члену.

        //        private WebClient<myWebClient>5__2;


        //        Данный метод создаётся при паттерне async await и помогает нам менять state

        //        private void MoveNext()
        //        {
        //          Создание переменной и присвоение значения state
        //        int num = <> 1__state;
        //        try
        //        {
        //                <uri > 5__1 = new Uri(fireUrl);
        //                <myWebClient > 5__2 = new WebClient();
        //                <myWebClient > 5__2.DownloadFile(< uri > 5__1, string.Concat(Enumerable.Last(< uri > 5__1.Segments), ".png"));
        //        }
        //        catch (Exception exception)
        //        {
        //                <> 1__state = -2;
        //                < uri > 5__1 = null;
        //                < myWebClient > 5__2 = null;
        //                <> t__builder.SetException(exception);
        //            return;
        //        }
        //            <> 1__state = -2;
        //            < uri > 5__1 = null;
        //            < myWebClient > 5__2 = null;
        //            <> t__builder.SetResult();
        //    }
        //    void IAsyncStateMachine.MoveNext()
        //    {
        //        //ILSpy generated this explicit interface implementation from .override directive in MoveNext
        //        this.MoveNext();
        //    }
        //    [DebuggerHidden]
        //    private void SetStateMachine(IAsyncStateMachine stateMachine)
        //    {
        //    }
        //    void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        //    {
        //        //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
        //        this.SetStateMachine(stateMachine);
        //    }
        //}
        public async Task Download(string fileUrl)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    await webClient.DownloadFileTaskAsync(new Uri(fileUrl), new Uri(fileUrl).Segments.Last() + ".png");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to download File" + ex.Message );
            }
        }

    //[AsyncStateMachine(typeof(< Download > d__0))]
    //[DebuggerStepThrough]
    //public Task Download(string fireUrl)
    //{
    //        < Download > d__0 stateMachine = new < Download > d__0();
    //    stateMachine.<> t__builder = AsyncTaskMethodBuilder.Create();
    //    stateMachine.<> 4__this = this;
    //    stateMachine.fireUrl = fireUrl;
    //    stateMachine.<> 1__state = -1;
    //    stateMachine.<> t__builder.Start(ref stateMachine);
    //    return stateMachine.<> t__builder.Task;
    //}

    }
}
