export async function loadDictionary(name: string): Promise<Record<string, any>> {
    const data = await import(`@/dictionary/${name}.json`, {
        assert: {
            type: "json"
        }
    });

    return data.default;
}