public class JsonUtils{
    public static string stringfyMessageModel(object model){

      string output = Newtonsoft.Json.JsonConvert.SerializeObject(model);
      return output;
    }
}