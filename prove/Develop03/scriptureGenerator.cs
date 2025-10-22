using System;


public class ScriptureGenrator
{
    private List<Scripture> _scriptures;

    public ScriptureGenrator()
    {
        _scriptures = new List<Scripture>();

        _scriptures.Add(new Scripture(

        new Reference("1 Nephi", 3, 7),
        "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."));

        _scriptures.Add(new Scripture(

        new Reference("Phillipians", 4, 13),
        "I can do all things through Christ which strengtheneth me."));

        _scriptures.Add(new Scripture(
        new Reference("Moroni", 10, 3, 5),

        "Behold, I would exhort you that when ye shall read these things, if it be wisdom in God that ye should read them, that ye would remember how merciful the Lord hath been unto the children of men, from the creation of Adam even down until the time that ye shall receive these things, and ponder it in your hearts. And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things."
        ));

        _scriptures.Add(new Scripture(

        new Reference("Doctrine and Covenants", 9, 7, 8),

        "Behold, you have not understood; you have supposed that I would give it unto you, when you took no thought save it was to ask me. But, behold, I say unto you, that you must study it out in your mind; then you must ask me if it be right, and if it is right I will cause that your bosom shall burn within you; therefore, you shall feel that it is right."
        ));

        _scriptures.Add(new Scripture(
        new Reference("Doctrine and Covenants", 4, 1, 7),

        "Now behold, a marvelous work is about to come forth among the children of men. Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day. Therefore, if ye have desires to serve God ye are called to the work; For behold the field is white already to harvest; and lo, he that thrusteth in his sickle with his might, the same layeth up in store that he perisheth not, but bringeth salvation to his soul; And faith, hope, charity and love, with an eye single to the glory of God, qualify him for the work. Remember faith, virtue, knowledge, temperance, patience, brotherly kindness, godliness, charity, humility, diligence. Ask, and ye shall receive; knock, and it shall be opened unto you. Amen."
        ));

    }
    public Scripture GetRandomScripture()
    {
        Random _random = new Random();
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }

}